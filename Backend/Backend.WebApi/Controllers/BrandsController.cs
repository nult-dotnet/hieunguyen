using System.Threading.Tasks;
using Backend.Application.Brands.Commands.CreateBrand;
using Backend.Application.Brands.Commands.UpdateBrandPatch;
using Backend.Application.Brands.Models;
using Backend.Application.Brands.Queries.GetAllBrand;
using Backend.Application.Brands.Queries.GetBrandById;
using Backend.Application.Brands.Queries.GetBrandByOwnerUser;
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
    public class BrandsController : BaseController
    {
        private readonly IMediator _mediator;

        public BrandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateBrandResource request)
        {
            var model = new CreateBrandCommand(request);
            return Ok(await _mediator.Send(model));
        }

        [HttpPatch("update/{id}")]
        [Authorize]
        public async Task<IActionResult> UpdatePatch(int id, JsonPatchDocument request)
        {
            var model = new UpdateBrandPatchCommand(id, request);
            return Ok(await _mediator.Send(model));
        }

        [HttpGet("get-all")]
        [AuthorizeRoles(Constants.ADMIN)]
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
        [Authorize]
        public async Task<IActionResult> GetByOwner()
        {
            var model = new GetBrandByOwnerUserQuery();
            return Ok(await _mediator.Send(model));
        }
    }
}
