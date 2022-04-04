using Backend.Application.Common.Models;
using Backend.Application.Products.Models;
using Backend.Application.Products.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<ApiResult<string>>
    {
        public CreateProductCommand(CreateProductResource createProductResource)
        {
            CreateProductResource = createProductResource;
        }

        public CreateProductResource CreateProductResource { get; set; }
    }

    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ApiResult<string>>
    {
        private readonly IProductService _productService;

        public CreateProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ApiResult<string>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            return await _productService.CreateAsync(request.CreateProductResource);
        }
    }
}
