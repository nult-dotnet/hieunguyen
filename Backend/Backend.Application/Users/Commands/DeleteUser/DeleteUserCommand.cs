using System.Threading;
using System.Threading.Tasks;
using Backend.Application.Common.Models;
using Backend.Application.Users.Services;
using MediatR;

namespace Backend.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<ApiResult<string>>
    {
        public int UserId { get; }

        public DeleteUserCommand(int userId)
        {
            UserId = userId;
        }
    }

    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, ApiResult<string>>
    {
        private readonly IUserService _userService;

        public DeleteUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ApiResult<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.DeleteAsync(request.UserId);
        }
    }
}
