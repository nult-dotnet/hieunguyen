﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Application.Brands.Models;
using Backend.Application.Common.Models;
using Backend.Data.Entities;
using Backend.Repository.UnitOfWork;
using Backend.Utilities.SystemConstants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;

namespace Backend.Application.Brands.Services
{
    public class BrandService : IBrandService
    {
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public BrandService(IMapper mapper, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _mapper = mapper; _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<ApiResult<List<Brand>>> GetAllAsync()
        {
            var listBrand = await _unitOfWork.Brands.FindAllAsync();

            return await Task.FromResult(new ApiSuccessResult<List<Brand>>(listBrand));
        }

        public async Task<ApiResult<Brand>> GetByIdAsync(int id)
        {
            var brand = await _unitOfWork.Brands.FindByIdAsync(id);

            return await Task.FromResult(new ApiSuccessResult<Brand>(brand));
        }

        public async Task<ApiResult<Brand>> GetByOwnerUser()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var brand = _unitOfWork.Brands
                .FindByCondition(x => x.UserId.Equals(int.Parse(userId)))
                .FirstOrDefault();

            return await Task.FromResult(new ApiSuccessResult<Brand>(brand));
        }

        public async Task<ApiResult<string>> CreateAsync(CreateBrandResource resource)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var currentBrand = _unitOfWork.Brands.FindByCondition(x => x.Name == resource.Name).FirstOrDefault();

            if (currentBrand != null)
            {
                return await Task.FromResult(new ApiErrorResult<string>("Thương hiệu đã tồn tại"));
            }

            var brand = _mapper.Map<Brand>(resource);
            brand.UserId = int.Parse(userId);
            brand.TotalRate = 0;

            var user = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.AddToRoleAsync(user, Constants.PARTNER_ROLE_NAME);

            if (!result.Succeeded)
                return await Task.FromResult(new ApiErrorResult<string>("Không thể thêm thương hiệu"));

            await _unitOfWork.Brands.CreateAsync(brand);
            await _unitOfWork.SaveChangesAsync();

            return await Task.FromResult(new ApiSuccessResult<string>("Thêm thương hiệu thành công"));

        }

        public async Task<ApiResult<string>> UpdatePatchAsync(int id, JsonPatchDocument patchDocument)
        {
            var brand = await _unitOfWork.Brands.FindByIdAsync(id);

            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (brand.UserId != int.Parse(userId))
            {
                return await Task.FromResult(new ApiErrorResult<string>("Bạn không có quyền cập nhật"));
            }

            patchDocument.ApplyTo(brand);

            //var currentBrand = _unitOfWork.Brands.FindByCondition(x => x.Name == brand.Name).FirstOrDefault();

            //if (currentBrand != null)
            //{
            //    return await Task.FromResult(new ApiSuccessResult<string>("Tên thương hiệu đã tồn tại"));
            //}

            await _unitOfWork.SaveChangesAsync();

            return await Task.FromResult(new ApiSuccessResult<string>("Cập nhật thương hiệu thành công"));
        }
    }
}
