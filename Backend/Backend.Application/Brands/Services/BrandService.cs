﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Application.Brands.Extensions;
using Backend.Application.Brands.Models;
using Backend.Application.Common.Models;
using Backend.Data.Entities;
using Backend.Data.Enums;
using Backend.Repository.UnitOfWork;
using Backend.Utilities.SystemConstants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Brands.Services
{
    public class BrandService : IBrandService
    {
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public BrandService(IMapper mapper, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            _mapper = mapper; _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResult<List<Brand>>> GetAllAsync()
        {
            var listBrand = await _unitOfWork.Brands
                .FindByCondition(x => x.Status != (int)BrandStatus.STOP)
                .ToListAsync();

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
            var brand = await _unitOfWork.Brands
                .FindByCondition(x => x.UserId.Equals(int.Parse(userId)))
                .SingleOrDefaultAsync();

            return await Task.FromResult(new ApiSuccessResult<Brand>(brand));
        }

        public async Task<ApiResult<Brand>> CreateAsync(CreateBrandResource resource)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var currentBrand = await _unitOfWork.Brands
                .FindByCondition(x => x.Name == resource.Name && x.Status!=(int) BrandStatus.STOP)
                .SingleOrDefaultAsync();

            var isAdmin = _httpContextAccessor.HttpContext.User.IsInRole(Constants.ADMIN);
            var isPartner = _httpContextAccessor.HttpContext.User.IsInRole(Constants.PARTNER);

            if (currentBrand != null)
            {
                return await Task.FromResult(new ApiErrorResult<Brand>("Thương hiệu đã tồn tại"));
            }

            var brand = _mapper.Map<Brand>(resource);
            brand.Status = (int)BrandStatus.OPEN;

            if (!isAdmin)
            {
                brand.UserId = int.Parse(userId);
                var user = await _unitOfWork.Users.FindByIdAsync(int.Parse(userId));
                if (!isPartner)
                {
                    await _unitOfWork.UserRoles.CreateAsync(new UserRole()
                    {
                        UserId = int.Parse(userId),
                        RoleId = 2
                    });
                }
                else
                {
                    return await Task.FromResult(new ApiErrorResult<Brand>("Người dùng đã có thương thiệu"));
                }

            }

            brand.TotalRate = 0;

            await _unitOfWork.Brands.CreateAsync(brand);
            await _unitOfWork.SaveChangesAsync();

            return await Task.FromResult(new ApiSuccessResult<Brand>(brand));

        }

        public async Task<ApiResult<string>> UpdatePatchAsync(int id, JsonPatchDocument patchDocument)
        {
            var brand = await _unitOfWork.Brands.FindByIdAsync(id);

            try
            {
                patchDocument.ApplyTo(brand);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return await Task.FromResult(new ApiErrorResult<string>(e.Message));
            }

            return await Task.FromResult(new ApiSuccessResult<string>("Cập nhật thương hiệu thành công"));
        }

        public async Task<ApiResult<Brand>> UpdateAsync(int id, UpdateBrandResource resource)
        {
            var brand = await _unitOfWork.Brands.FindByIdAsync(id);
            brand.Map(resource);

            try
            {
                _unitOfWork.Brands.Update(brand);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return await Task.FromResult(new ApiErrorResult<Brand>(e.Message));
            }

            return await Task.FromResult(new ApiSuccessResult<Brand>(brand));
        }

        public async Task<ApiResult<string>> DeleteAsync(int id)
        {
            var brand = await _unitOfWork.Brands.FindByIdAsync(id);
            brand.Status = (int)BrandStatus.STOP;
            _unitOfWork.Brands.Update(brand);
            await _unitOfWork.SaveChangesAsync();
            return await Task.FromResult(new ApiSuccessResult<string>("Xóa thương hiệu thành công."));
        }
    }
}
