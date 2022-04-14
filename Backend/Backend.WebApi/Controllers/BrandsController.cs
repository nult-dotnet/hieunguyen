using System.Threading.Tasks;
using Backend.Application.Brands.Commands.CreateBrand;
using Backend.Application.Brands.Commands.DeleteBrand;
using Backend.Application.Brands.Commands.UpdateBrand;
using Backend.Application.Brands.Commands.UpdateBrandPatch;
using Backend.Application.Brands.Models;
using Backend.Application.Brands.Queries.GetAllBrand;
using Backend.Application.Brands.Queries.GetBrandById;
using Backend.Application.Brands.Queries.GetBrandByOwnerUser;
using Backend.Data.Entities;
using Backend.Utilities.SystemConstants;
using Backend.WebApi.ActionFilters;
using Backend.WebApi.AuthorizeRoles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BrandsController : BaseController
    {
        private readonly IMediator _mediator;

        public BrandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [AuthorizeRoles(Constants.ADMIN, Constants.USER)]
        public async Task<IActionResult> Create([FromBody] CreateBrandResource request)
        {
            var model = new CreateBrandCommand(request);
            return Ok(await _mediator.Send(model));
        }

        [HttpPatch("update/{id}")]
        [AuthorizeRoles(Constants.ADMIN, Constants.PARTNER)]
        public async Task<IActionResult> UpdatePatch(int id, [FromBody]JsonPatchDocument request)
        {
            var model = new UpdateBrandPatchCommand(id, request);
            return Ok(await _mediator.Send(model));
        }

        [HttpPut("update/{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [AuthorizeRoles(Constants.ADMIN, Constants.PARTNER)]
        public async Task<IActionResult> Update(int id, UpdateBrandResource request)
        {
            var model = new UpdateBrandComand(id, request);
            return Ok(await _mediator.Send(model));
        }

        [HttpGet("get-all")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var model = new GetAllBrandQuery();
            return Ok(await _mediator.Send(model));
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var model = new GetBrandByIdQuery(id);
            return Ok(await _mediator.Send(model));
        }

        [HttpGet("get-by-owner")]
        [AuthorizeRoles(Constants.PARTNER, Constants.USER)]
        public async Task<IActionResult> GetByOwner()
        {
            var model = new GetBrandByOwnerUserQuery();
            return Ok(await _mediator.Send(model));
        }

        [HttpDelete("delete/{id}")]
        [AuthorizeRoles(Constants.ADMIN)]
        public async Task<IActionResult> Delete(int id)
        {
            var model = new DeleteBrandCommand(id);
            return Ok(await _mediator.Send(model));
        }
    }
}
