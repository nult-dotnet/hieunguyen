using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Backend.Application.Common.Models;
using Backend.Application.Users.Models;
using Backend.Application.Users.Services;
using MediatR;

namespace Backend.Application.Users.Queries.GetAllUser
{
    public class GetAllUserQuery : IRequest<ApiResult<List<UserVm>>>
    {
    }

    public class GetAllUserHandler : IRequestHandler<GetAllUserQuery, ApiResult<List<UserVm>>>
    {
        private readonly IUserService _userService;

        public GetAllUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ApiResult<List<UserVm>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetAllAsync();
        }
    }
}
