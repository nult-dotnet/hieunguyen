using Backend.Application.Common.Models;
using Backend.Application.Users.Models;
using Backend.Application.Users.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<ApiResult<string>>
    {
        public CreateUserCommand(CreateUserResource createUserResource)
        {
            CreateUserResource = createUserResource;
        }

        public CreateUserResource CreateUserResource { get; }
    }

    public class CreateUserHandler : IRequestHandler<CreateUserCommand, ApiResult<string>>
    {
        private readonly IUserService _userService;

        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ApiResult<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.CreateAsync(request.CreateUserResource);
        }
    }
}
