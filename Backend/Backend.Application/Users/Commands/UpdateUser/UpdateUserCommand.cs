using Backend.Application.Common.Models;
using Backend.Application.Users.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Backend.Application.Users.Models;

namespace Backend.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<ApiResult<string>>
    {
        public int Id { get; set; }
        public UpdateUserResource UpdateUserResource { get; set; }

        public UpdateUserCommand(int id, UpdateUserResource updateUserResource)
        {
            Id = id;
            UpdateUserResource = updateUserResource;
        }
    }

    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ApiResult<string>>
    {
        private readonly IUserService _userService;

        public UpdateUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ApiResult<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.UpdateAsync(request.Id, request.UpdateUserResource);
        }
    }
}
