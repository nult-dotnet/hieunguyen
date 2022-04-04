using System.Threading.Tasks;
using Backend.Application.Products.Commands.CreateProduct;
using Backend.Application.Products.Commands.DeleteProduct;
using Backend.Application.Products.Commands.UpdateProduct;
using Backend.Application.Products.Models;
using Backend.Utilities.SystemConstants;
using Backend.WebApi.ActionFilters;
using Backend.WebApi.AuthorizeRoles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizeRoles(Constants.PARTNER, Constants.USER)]
    public class ProductsController : BaseController
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Create([FromForm] CreateProductResource resource)
        {
            var model = new CreateProductCommand(resource);
            return Ok(await _mediator.Send(model));
        }

        [HttpPut("update/{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductResource resource)
        {
            var model = new UpdateProductCommand(id, resource);
            return Ok(await _mediator.Send(model));
        }

        [HttpDelete("delete/{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Delete(int id)
        {
            var model = new DeleteProductCommand(id);
            return Ok(await _mediator.Send(model));
        }
    }
}
