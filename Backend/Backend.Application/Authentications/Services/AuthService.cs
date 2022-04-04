using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Application.Authentications.Models;
using Backend.Application.Common.Models;
using Backend.Data.Entities;
using Backend.Data.Enums;
using Backend.Repository.UnitOfWork;
using Backend.Utilities.SystemConstants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Application.Authentications.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager,
            IConfiguration config, IHttpContextAccessor httpContextAccessor, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResult<string>> AuthenticateAsync(AuthenticateResource request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null || user.Status.Equals(UserStatus.DELETED))
            {
                return new ApiErrorResult<string>("Tài khoản không tồn tại");
            }

            if (user.Status.Equals(UserStatus.DISABLE))
            {
                return new ApiErrorResult<string>("Tài khoản đã bị khóa");
            }

            if (user.PasswordHash is null)
            {
                return new ApiErrorResult<string>("Đăng nhập thất bại, sai phương thức đăng nhập.");
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName,
                request.Password, request.RememberMe, true);

            if (!result.Succeeded)
            {
                return new ApiErrorResult<string>("Đăng nhập thất bại");
            }

            var roles = await _userManager.GetRolesAsync(user);

            var token = CreateToken(roles, user);

            return await Task.FromResult(new ApiSuccessResult<string>(token));
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

        public async Task<bool> SignOutAsync()
        {
            await _signInManager.SignOutAsync();
            _httpContextAccessor.HttpContext.Session.Remove(Constants.CURRENT_USER);
            return true;
        }

        public async Task<ApiResult<string>> ForgotPasswordAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user is null)
            {
                return await Task.FromResult(new ApiErrorResult<string>("Tài khoản không tồn tại"));
            }

            string token = await _userManager.GeneratePasswordResetTokenAsync(user);

            return await Task.FromResult(new ApiSuccessResult<string>(token));
        }

        public async Task<ApiResult<string>> ResetPasswordAsync(ResetPasswordResource request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null)
            {
                return await Task.FromResult(new ApiErrorResult<string>("Người dùng không tồn tại"));
            }

            var result = await _userManager.ResetPasswordAsync(user, request.Token, request.Password);

            if (result.Succeeded)
            {
                return await Task.FromResult(new ApiSuccessResult<string>("Đã cập nhật mật khẩu"));
            }

            return await Task.FromResult(new ApiErrorResult<string>("Tạo mới mật khẩu thất bại"));
        }
    }
}
