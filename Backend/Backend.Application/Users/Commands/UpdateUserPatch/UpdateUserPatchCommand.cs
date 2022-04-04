using System.Threading;
using System.Threading.Tasks;
using Backend.Application.Common.Models;
using Backend.Application.Users.Services;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace Backend.Application.Users.Commands.UpdateUserPatch
{
    public class UpdateUserPatchCommand : IRequest<ApiResult<string>>
    {
        public int Id { get; set; }
        public JsonPatchDocument UpdateUserPatch { get; set; }

        public UpdateUserPatchCommand(int id, JsonPatchDocument updateUserPatch)
        {
            Id = id;
            UpdateUserPatch = updateUserPatch;
        }
    }

    public class UpdateUserHandler : IRequestHandler<UpdateUserPatchCommand, ApiResult<string>>
    {
        private readonly IUserService _userService;

        public UpdateUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ApiResult<string>> Handle(UpdateUserPatchCommand request, CancellationToken cancellationToken)
        {
            return await _userService.UpdatePatchAsync(request.Id, request.UpdateUserPatch);
        }
    }
}
