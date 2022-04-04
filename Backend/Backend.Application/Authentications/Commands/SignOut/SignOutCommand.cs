using System.Threading;
using System.Threading.Tasks;
using Backend.Application.Authentications.Services;
using MediatR;

namespace Backend.Application.Authentications.Commands.SignOut
{
    public class SignOutCommand : IRequest<bool>
    {

    }

    public class SignOutHandler : IRequestHandler<SignOutCommand, bool>
    {
        private readonly IAuthService _authService;

        public SignOutHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<bool> Handle(SignOutCommand request, CancellationToken cancellationToken)
        {
            return await _authService.SignOutAsync();
        }
    }
}
