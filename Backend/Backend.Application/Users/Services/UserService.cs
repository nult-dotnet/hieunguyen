using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Application.Common.Models;
using Backend.Application.Users.Extensions;
using Backend.Application.Users.Models;
using Backend.Data.Entities;
using Backend.Data.Enums;
using Backend.Repository.UnitOfWork;
using Backend.Utilities.SystemConstants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Users.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(UserManager<User> userManager, IMapper mapper,
            IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResult<string>> CreateAsync(CreateUserResource request)
        {
            var userEmail = await _userManager.FindByEmailAsync(request.Email);
            var listUser = await _unitOfWork.Users
                .FindByCondition(x => x.UserName.Equals(request.UserName) && x.Status != UserStatus.DELETED)
                .ToListAsync();

            if (userEmail != null || listUser.Count > 0)
            {
                return new ApiErrorResult<string>("Tài khoản đã tồn tại!");
            }

            var user = _mapper.Map<User>(request);
            user.CreatedDate = DateTime.Now;
            user.Status = UserStatus.ACTIVE;
            user.CreatedBy = request.UserName;

            try
            {
                await _userManager.CreateAsync(user, request.Password);
                await _userManager.AddToRoleAsync(user, Constants.USER_ROLE_NAME);
            }
            catch
            {
                await _userManager.DeleteAsync(user);
                return await Task.FromResult(new ApiErrorResult<string>("Đăng ký thất bại"));
            }

            return await Task.FromResult(new ApiSuccessResult<string>("Thêm người dùng thành công"));
        }

        public async Task<ApiResult<UserVm>> GetByIdAsync(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user is null || user.Status.Equals(UserStatus.DELETED))
            {
                return new ApiErrorResult<UserVm>("Người dùng không tồn tại");
            }

            var result = _mapper.Map<UserVm>(user);
            var roles = await _userManager.GetRolesAsync(user);
            result.UserInRole = roles.ToList();

            return await Task.FromResult(new ApiSuccessResult<UserVm>(result));
        }

        public async Task<ApiResult<List<UserVm>>> GetAllAsync()
        {
            var users = await _unitOfWork.Users
                .FindByCondition(x => x.Status != UserStatus.DELETED)
                .ToListAsync();

            if (users is null)
            {
                return new ApiErrorResult<List<UserVm>>("Không tìm thấy được người dùng nào.");
            }

            var result = _mapper.Map<List<UserVm>>(users);

            for (var i = 0; i < users.Count; i++)
            {
                var role = await _userManager.GetRolesAsync(users[i]);
                result[i].UserInRole = role.ToList();
            }

            return await Task.FromResult(new ApiSuccessResult<List<UserVm>>(result));
        }

        public async Task<ApiResult<string>> UpdateAsync(int id, UpdateUserResource request)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user is null)
            {
                return new ApiErrorResult<string>("Người dùng không tồn tại");
            }

            var username = _httpContextAccessor.HttpContext.User.Identity.Name;

            try
            {
                user.Map(request);
                user.ModifiedBy = username;
                await _userManager.UpdateAsync(user);
            }
            catch
            {
                return await Task.FromResult(new ApiErrorResult<string>("Cập nhật thông tin người dùng thất bại"));
            }

            return await Task.FromResult(new ApiSuccessResult<string>("Cập nhật người dùng thành công"));
        }

        public async Task<ApiResult<string>> DeleteAsync(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user is null)
            {
                return new ApiErrorResult<string>("Người dùng không tồn tại");
            }

            user.Status = UserStatus.DELETED;
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return await Task.FromResult(new ApiSuccessResult<string>("Xóa người dùng thành công"));
            }

            return await Task.FromResult(new ApiErrorResult<string>("Xóa người dùng thất bại"));
        }

        public async Task<ApiResult<string>> UpdatePatchAsync(int id, JsonPatchDocument request)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user is null)
            {
                return new ApiErrorResult<string>("Người dùng không tồn tại");
            }

            var username = _httpContextAccessor.HttpContext.User.Identity.Name;

            user.ModifiedBy = username;
            request.ApplyTo(user);

            await _unitOfWork.SaveChangesAsync();

            return await Task.FromResult(new ApiSuccessResult<string>("Cập nhật người dùng thành công"));
        }
    }
}
