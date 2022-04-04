using System.Threading;
using System.Threading.Tasks;
using Backend.Application.Common.Models;
using Backend.Application.Users.Models;
using Backend.Application.Users.Services;
using MediatR;

namespace Backend.Application.Users.Queries.GetUserById
{
    public class GetByIdUserQuery : IRequest<ApiResult<UserVm>>
    {
        public int UserId { get; }

        public GetByIdUserQuery(int userId)
        {
            UserId = userId;
        }
    }

    public class GetByIdHandler : IRequestHandler<GetByIdUserQuery, ApiResult<UserVm>>
    {
        private readonly IUserService _userService;

        public GetByIdHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ApiResult<UserVm>> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetByIdAsync(request.UserId);
        }
    }
}
