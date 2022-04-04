using System.Threading;
using System.Threading.Tasks;
using Backend.Application.Authentications.Models;
using Backend.Application.Authentications.Services;
using Backend.Application.Common.Models;
using MediatR;

namespace Backend.Application.Authentications.Commands.ResetPassword
{
    public class ResetPasswordCommand : IRequest<ApiResult<string>>
    {
        public ResetPasswordCommand(ResetPasswordResource resetPassword)
        {
            ResetPassword = resetPassword;
        }

        public ResetPasswordResource ResetPassword { get; set; }
    }

    public class ResetPasswordHandler : IRequestHandler<ResetPasswordCommand, ApiResult<string>>
    {
        private readonly IAuthService _authService;

        public ResetPasswordHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<ApiResult<string>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            return await _authService.ResetPasswordAsync(request.ResetPassword);
        }
    }
}
