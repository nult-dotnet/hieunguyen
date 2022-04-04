using System.Threading.Tasks;
using Backend.Application.Authentications.Models;
using Backend.Application.Common.Models;

namespace Backend.Application.Authentications.Services
{
    public interface IAuthService
    {
        Task<ApiResult<string>> AuthenticateAsync(AuthenticateResource request);
        Task<bool> SignOutAsync();
        Task<ApiResult<string>> ForgotPasswordAsync(string email);
        Task<ApiResult<string>> ResetPasswordAsync(ResetPasswordResource request);
    }
}
