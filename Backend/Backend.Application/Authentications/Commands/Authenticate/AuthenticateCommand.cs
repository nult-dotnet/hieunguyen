using System.Threading;
using System.Threading.Tasks;
using Backend.Application.Authentications.Models;
using Backend.Application.Authentications.Services;
using Backend.Application.Common.Models;
using MediatR;

namespace Backend.Application.Authentications.Commands.Authenticate
{
    public class AuthenticateCommand : IRequest<ApiResult<string>>
    {
        public AuthenticateCommand(AuthenticateResource authenticate)
        {
            Authenticate = authenticate;
        }

        public AuthenticateResource Authenticate { get; set; }
    }

    public class AuthenticateHandler : IRequestHandler<AuthenticateCommand, ApiResult<string>>
    {
        private readonly IAuthService _authService;

        public AuthenticateHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<ApiResult<string>> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            return await _authService.AuthenticateAsync(request.Authenticate);
        }
    }
}
