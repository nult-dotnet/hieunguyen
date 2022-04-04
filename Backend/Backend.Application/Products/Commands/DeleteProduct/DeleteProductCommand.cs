using System.Threading;
using System.Threading.Tasks;
using Backend.Application.Common.Models;
using Backend.Application.Products.Services;
using MediatR;

namespace Backend.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<ApiResult<string>>
    {
        public DeleteProductCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, ApiResult<string>>
    {
        private readonly IProductService _productService;

        public DeleteProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ApiResult<string>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await _productService.DeleteAsync(request.Id);
        }
    }
}
