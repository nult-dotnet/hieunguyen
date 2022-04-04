using Backend.Application.Common.Models;
using Backend.Application.Products.Models;
using Backend.Application.Products.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<ApiResult<string>>
    {
        public UpdateProductCommand(int id, UpdateProductResource updateProductResource)
        {
            Id = id;
            UpdateProductResource = updateProductResource;
        }

        public int Id { get; set; }
        public UpdateProductResource UpdateProductResource { get; set; }
    }

    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ApiResult<string>>
    {
        private readonly IProductService _productService;

        public UpdateProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ApiResult<string>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            return await _productService.UpdateAsync(request.Id, request.UpdateProductResource);
        }
    }
}
