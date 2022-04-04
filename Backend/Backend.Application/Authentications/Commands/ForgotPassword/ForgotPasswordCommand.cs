using System.Threading;
using System.Threading.Tasks;
using Backend.Application.Authentications.Models;
using Backend.Application.Authentications.Services;
using Backend.Application.Common.Models;
using MediatR;

namespace Backend.Application.Authentications.Commands.ForgotPassword
{
    public class ForgotPasswordCommand : IRequest<ApiResult<string>>
    {
        public ForgotPasswordCommand(ForgotPasswordResource forgotPassword)
        {
            ForgotPassword = forgotPassword;
        }

        public ForgotPasswordResource ForgotPassword { get; set; }
    }

    public class ForgotPasswordHandler : IRequestHandler<ForgotPasswordCommand, ApiResult<string>>
    {
        private readonly IAuthService _authService;

        public ForgotPasswordHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<ApiResult<string>> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            return await _authService.ForgotPasswordAsync(request.ForgotPassword.Email);
        }
    }
}
