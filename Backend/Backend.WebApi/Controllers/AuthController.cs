using Backend.Application.Authentications.Commands.Authenticate;
using Backend.Application.Authentications.Commands.ForgotPassword;
using Backend.Application.Authentications.Commands.ResetPassword;
using Backend.Application.Authentications.Commands.SignOut;
using Backend.WebApi.ActionFilters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Backend.Application.Authentications.Models;

namespace Backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateResource request)
        {
            var model = new AuthenticateCommand(request);
            var result = await _mediator.Send(model);

            return Ok(result);
        }


        [HttpPost("forgot-password")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordResource request)
        {
            var model = new ForgotPasswordCommand(request);
            var result = await _mediator.Send(model);

            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("reset-password")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordResource request)
        {
            var model = new ResetPasswordCommand(request);
            return Ok(await _mediator.Send(model));
        }

        [HttpPost("sign-out")]
        public async Task<IActionResult> SignOut()
        {
            await _mediator.Send(new SignOutCommand());

            return NoContent();
        }
    }
}
