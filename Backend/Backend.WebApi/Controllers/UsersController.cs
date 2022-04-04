using Backend.Application.Common.Models;
using Backend.WebApi.ActionFilters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Backend.Application.Users.Commands.CreateUser;
using Backend.Application.Users.Commands.DeleteUser;
using Backend.Application.Users.Commands.UpdateUser;
using Backend.Application.Users.Commands.UpdateUserPatch;
using Backend.Application.Users.Models;
using Backend.Application.Users.Queries.GetAllUser;
using Backend.Application.Users.Queries.GetUserById;
using Backend.Application.Users.Services;
using Backend.Utilities.SystemConstants;
using Microsoft.AspNetCore.JsonPatch;

namespace Backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _user;

        public UsersController(IMediator mediator, IHttpContextAccessor httpContextAccessor, IUserService user)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
            _user = user;
        }

        [HttpPost("create")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CreateUserResource request)
        {
            var model = new CreateUserCommand(request);
            return Ok(await _mediator.Send(model));
        }

        [HttpPut("update/{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [Authorize]
        public async Task<IActionResult> UpdateMe(int id, [FromBody] UpdateUserResource request)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (!userId.Equals(id.ToString()))
            {
                return Ok(new ApiErrorResult<string>("Thông tin chỉnh sửa không khớp với người dùng hiện tại."));
            }

            var model = new UpdateUserCommand(id, request);
            return Ok(await _mediator.Send(model));
        }

        [HttpPatch("update/{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [Authorize]
        public async Task<IActionResult> UpdateMePatch(int id, [FromBody] JsonPatchDocument request)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (!userId.Equals(id.ToString()))
            {
                return Ok(new ApiErrorResult<string>("Thông tin chỉnh sửa không khớp với người dùng hiện tại."));
            }

            var model = new UpdateUserPatchCommand(id, request);
            return Ok(await _mediator.Send(model));
        }

        [HttpDelete("delete/{userId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [Authorize(Roles = Constants.ADMIN)]
        public async Task<IActionResult> Delete(int userId)
        {
            var query = new DeleteUserCommand(userId);

            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{userId}")]
        [Authorize(Roles = Constants.ADMIN)]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var query = new GetByIdUserQuery(userId);

            return Ok(await _mediator.Send(query));
        }

        [HttpGet("profile")]
        [Authorize]
        public async Task<IActionResult> GetProfile()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var query = new GetByIdUserQuery(int.Parse(userId));

            return Ok(await _mediator.Send(query));
        }

        [HttpGet("get-all")]
        [Authorize(Roles = Constants.ADMIN)]
        public async Task<IActionResult> GetAllUser()
        {
            var query = new GetAllUserQuery();

            return Ok(await _mediator.Send(query));
        }
    }
}
