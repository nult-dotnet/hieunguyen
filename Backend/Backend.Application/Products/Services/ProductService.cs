using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Application.Common.Models;
using Backend.Application.Products.Extensions;
using Backend.Application.Products.Models;
using Backend.Data.Entities;
using Backend.Data.Enums;
using Backend.Infrastructure.FileImage;
using Backend.Repository.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Backend.Application.Products.Services
{
    public class ProductService : IProductService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly IStorageService _storageService;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IHttpContextAccessor httpContextAccessor, IMapper mapper, IStorageService storageService, IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _storageService = storageService;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResult<string>> CreateAsync(CreateProductResource request)
        {
            var product = _mapper.Map<Product>(request);

            product.CreatedDate = DateTime.Now;
            product.Inventory = request.GoodsReceipt;

            string path = _storageService.CreateProductPath(request.CategoryId, request.Name);

            try
            {
                product.ProductPhotos = new List<ProductPhoto>();

                foreach (var i in request.ThumbnailImages)
                {
                    product.ProductPhotos.Add(
                        new ProductPhoto()
                        {
                            IsDefault = true,
                            Url = await _storageService.SaveFile(path, i)
                        });
                }

                await _unitOfWork.Products.CreateAsync(product);
                await _unitOfWork.SaveChangesAsync();
                
                return new ApiSuccessResult<string>("Thêm sản phẩm thành công");
            }
            catch
            {
                return new ApiErrorResult<string>("Thêm sản phẩm thất bại");
            }
        }

        public async Task<ApiResult<string>> UpdateAsync(int id, UpdateProductResource update)
        {
            var product = await _unitOfWork.Products.FindByIdAsync(id);

            if (product is null)
            {
                return await Task.FromResult(new ApiErrorResult<string>("Không tìm thấy sản phẩm cần cập nhật"));
            }

            string sPath = _storageService.CreateProductPath(product.CategoryId, product.Name);

            string dPath = _storageService.CreateProductPath(product.CategoryId, update.Name);

            _storageService.ChangeNameFolder(sPath, dPath);

            product.Map(update);

            var currentUser = _httpContextAccessor.HttpContext.User.Identity.Name;

            _unitOfWork.Products.Update(product);

            await _unitOfWork.SaveChangesAsync();

            return await Task.FromResult(new ApiSuccessResult<string>("Cập nhật sản phẩm thành công"));
        }

        public async Task<ApiResult<string>> DeleteAsync(int productId)
        {
            var product = await _unitOfWork.Products.FindByIdAsync(productId);

            if (product is null)
            {
                return await Task.FromResult(new ApiErrorResult<string>("Không tìm thấy sản phẩm cần xóa"));
            }

            product.Status = ProductStatus.DELETED;
            product.ModifiedDate = DateTime.Now;

            _unitOfWork.Products.Update(product);

            await _unitOfWork.SaveChangesAsync();

            return await Task.FromResult(new ApiSuccessResult<string>("Xóa sản phẩm thành công"));
        }

        public async Task<ApiResult<Product>> GetProductByIdAsync(int productId)
        {
            var product = await _unitOfWork.Products
                .FindByCondition(x => x.Id == productId && x.Status != ProductStatus.DELETED)
                .Include(x=>x.ProductPhotos)
                .SingleOrDefaultAsync();

            if (product is null)
            {
                return await Task.FromResult(new ApiErrorResult<Product>("Không tìm thấy sản phẩm"));
            }

            var path = _storageService.CreateProductPath(product.CategoryId, product.Name);

            foreach (var p in product.ProductPhotos)
            {
                p.Url = "https://localhost:5001/" + path + "/" + p.Url;
            }

            return await Task.FromResult(new ApiSuccessResult<Product>(product));
        }

        public async Task<ApiResult<List<Product>>> GetAllProductAsync()
        {
            var products = await _unitOfWork.Products
                .FindByCondition(x => x.Status != ProductStatus.DELETED)
                .ToListAsync();

            if (products is null)
            {
                return await Task.FromResult(new ApiErrorResult<List<Product>>("Không tìm thấy sản phẩm"));
            }

            return await Task.FromResult(new ApiSuccessResult<List<Product>>(products));
        }

        public async Task<ApiResult<string>> DisableAsync(int productId)
        {
            var product = await _unitOfWork.Products
                .FindByCondition(x => x.Id == productId
                                      && x.Status != ProductStatus.DELETED
                                      && x.Status != ProductStatus.HIDDEN)
                .SingleOrDefaultAsync();

            if (product is null)
            {
                return await Task.FromResult(new ApiErrorResult<string>("Không tìm thấy sản phẩm"));
            }

            product.Status = ProductStatus.HIDDEN;
            product.ModifiedDate = DateTime.Now;

            _unitOfWork.Products.Update(product);
            await _unitOfWork.SaveChangesAsync();

            return await Task.FromResult(new ApiSuccessResult<string>("Khóa sản phẩm thành công"));
        }

        public async Task<ApiResult<string>> EnableAsync(int productId)
        {
            var product = await _unitOfWork.Products
                .FindByCondition(x => x.Id == productId
                                      && x.Status != ProductStatus.DELETED
                                      && x.Status == ProductStatus.HIDDEN)
                .SingleOrDefaultAsync();

            if (product is null)
            {
                return await Task.FromResult(new ApiErrorResult<string>("Không tìm thấy sản phẩm"));
            }

            product.Status = ProductStatus.DEFAULT;
            product.ModifiedDate = DateTime.Now;

            _unitOfWork.Products.Update(product);
            await _unitOfWork.SaveChangesAsync();

            return await Task.FromResult(new ApiSuccessResult<string>("Mở khóa sản phẩm thành công"));
        }

        private async Task<List<Product>> CreatePathPhotos(List<Product> products)
        {
            foreach (var p in products)
            {
                var path = _storageService.CreateProductPath(p.CategoryId, p.Name);
                var photos = await _unitOfWork.ProductPhotos
                    .FindByCondition(x=>x.ProductId == p.Id)
                    .ToListAsync();
                p.ProductPhotos = new List<ProductPhoto>();

                for (var i = 0; i < 2; i++)
                {
                    if (photos.Count >= 2)
                    {
                        p.ProductPhotos.Add(photos[i]);
                        p.ProductPhotos.ElementAt(i).Url = "https://localhost:5001/" + path + "/" + photos[i].Url;
                    }
                }
            }

            return products;
        }
    }
}
