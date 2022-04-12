using Backend.Application.Authentications.Models;
using Backend.Application.Common.Models;
using Backend.Data.Entities;
using Backend.Data.Enums;
using Backend.Repository.Generic;
using Backend.Repository.UnitOfWork;
using Backend.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Authentications.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<UserRole> _userRoleRepository;

        public AuthService(IConfiguration config)
        {
            _config = config;
            var unitOfWork = InstanceUnitOfWork.UnitOfWork();
            _userRepository = InstanceGenericRepository<User>.Repository(unitOfWork);
            _userRoleRepository = InstanceGenericRepository<UserRole>.Repository(unitOfWork);
        }

        public async Task<ApiResult<string>> AuthenticateAsync(AuthenticateResource request)
        {
            var user = await _userRepository
                .FindByCondition(x=>x.Email == request.Email)
                .SingleOrDefaultAsync();

            if (user is null || user.Status.Equals(UserStatus.DELETED))
            {
                return new ApiErrorResult<string>("Tài khoản không tồn tại");
            }

            if (user.Status.Equals(UserStatus.DISABLE))
            {
                return new ApiErrorResult<string>("Tài khoản đã bị khóa");
            }

            var result = await _userRepository
                .FindByCondition(x =>
                    x.Email == request.Email && x.PasswordHash == Encryptor.SHA256Hash(request.Password))
                .SingleOrDefaultAsync();

            if (result is null)
            {
                return await Task.FromResult(new ApiSuccessResult<string>("Đăng nhập thất bại"));
            }

            var userRoles = await _userRoleRepository
                .FindByCondition(x => x.UserId == user.Id)
                .ToListAsync();

            var roles = new List<string>();

            foreach (var r in userRoles)
            {
                switch (r.RoleId)
                {
                    case 1: roles.Add("Admin");
                        break;
                    case 2: roles.Add("Partner");
                        break;
                    default: roles.Add("User");
                        break;
                }
            }

            var token = CreateToken(roles, user);

            return await Task.FromResult(new ApiSuccessResult<string>(token));
        }

        public Task<bool> SignOutAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<string>> ForgotPasswordAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<string>> ResetPasswordAsync(ResetPasswordResource request)
        {
            throw new NotImplementedException();
        }

        private string CreateToken(IEnumerable<string> roles, User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, string.Join(",", roles)),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["JWT:ValidIssuer"],
                _config["JWT:ValidAudience"],
                claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: cred);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //public async Task<ApiResult<string>> ForgotPasswordAsync(string email)
        //{
        //    var user = await _userManager.FindByEmailAsync(email);

        //    if (user is null)
        //    {
        //        return await Task.FromResult(new ApiErrorResult<string>("Tài khoản không tồn tại"));
        //    }

        //    string token = await _userManager.GeneratePasswordResetTokenAsync(user);

        //    return await Task.FromResult(new ApiSuccessResult<string>(token));
        //}

        //public async Task<ApiResult<string>> ResetPasswordAsync(ResetPasswordResource request)
        //{
        //    var user = await _userManager.FindByEmailAsync(request.Email);

        //    if (user is null)
        //    {
        //        return await Task.FromResult(new ApiErrorResult<string>("Người dùng không tồn tại"));
        //    }

        //    var result = await _userManager.ResetPasswordAsync(user, request.Token, request.Password);

        //    if (result.Succeeded)
        //    {
        //        return await Task.FromResult(new ApiSuccessResult<string>("Đã cập nhật mật khẩu"));
        //    }

        //    return await Task.FromResult(new ApiErrorResult<string>("Tạo mới mật khẩu thất bại"));
        //}
    }
}
