using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Application.Common.Models;
using Backend.Application.Users.Extensions;
using Backend.Application.Users.Models;
using Backend.Data.Entities;
using Backend.Data.Enums;
using Backend.Repository.Generic;
using Backend.Repository.UnitOfWork;
using Backend.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Users.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<UserRole> _userRoleRepository;

        public UserService(IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = InstanceUnitOfWork.UnitOfWork();
            _userRepository = InstanceGenericRepository<User>.Repository(_unitOfWork);
            _userRoleRepository = InstanceGenericRepository<UserRole>.Repository(_unitOfWork);
        }

        public async Task<ApiResult<string>> CreateAsync(CreateUserResource request)
        {
            var userEmail = await _userRepository
                .FindByCondition(x => x.Email == request.Email)
                .SingleOrDefaultAsync();
            var listUser = await _userRepository
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
            user.PasswordHash = Encryptor.SHA256Hash(request.Password);

            try
            {
                await _userRepository.CreateAsync(user);
                await _unitOfWork.SaveChangesAsync();
                await _userRoleRepository.CreateAsync(new UserRole()
                {
                    UserId = user.Id,
                    RoleId = 3
                });
                await _unitOfWork.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return await Task.FromResult(new ApiErrorResult<string>("Đăng ký thất bại"));
            }

            return await Task.FromResult(new ApiSuccessResult<string>("Thêm người dùng thành công"));
        }

        public async Task<ApiResult<UserVm>> GetByIdAsync(int userId)
        {
            var user = await _userRepository.FindByIdAsync(userId);

            if (user is null || user.Status.Equals(UserStatus.DELETED))
            {
                return new ApiErrorResult<UserVm>("Người dùng không tồn tại");
            }

            var result = _mapper.Map<UserVm>(user);
            result.UserInRole = null;

            return await Task.FromResult(new ApiSuccessResult<UserVm>(result));
        }

        public async Task<ApiResult<List<UserVm>>> GetAllAsync()
        {
            var users = await _userRepository
                .FindByCondition(x => x.Status != UserStatus.DELETED)
                .ToListAsync();

            if (users is null)
            {
                return new ApiErrorResult<List<UserVm>>("Không tìm thấy được người dùng nào.");
            }

            var result = _mapper.Map<List<UserVm>>(users);

            return await Task.FromResult(new ApiSuccessResult<List<UserVm>>(result));
        }

        public async Task<ApiResult<string>> UpdateAsync(int id, UpdateUserResource request)
        {
            var user = await _userRepository.FindByIdAsync(id);

            if (user is null)
            {
                return new ApiErrorResult<string>("Người dùng không tồn tại");
            }

            var username = _httpContextAccessor.HttpContext.User.Identity.Name;

            try
            {
                user.Map(request);
                user.ModifiedBy = username;
                _userRepository.Update(user);
                await _unitOfWork.SaveChangesAsync();
            }
            catch
            {
                return await Task.FromResult(new ApiErrorResult<string>("Cập nhật thông tin người dùng thất bại"));
            }

            return await Task.FromResult(new ApiSuccessResult<string>("Cập nhật người dùng thành công"));
        }

        public async Task<ApiResult<string>> DeleteAsync(int userId)
        {
            var user = await _userRepository.FindByIdAsync(userId);
            if (user is null)
            {
                return new ApiErrorResult<string>("Người dùng không tồn tại");
            }

            user.Status = UserStatus.DELETED;
            _userRepository.Update(user);

            await _unitOfWork.SaveChangesAsync();

            return await Task.FromResult(new ApiErrorResult<string>("Xóa người dùng thất bại"));
        }

        public async Task<ApiResult<string>> UpdatePatchAsync(int id, JsonPatchDocument request)
        {
            var user = await _userRepository.FindByIdAsync(id);

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
