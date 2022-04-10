using System.Threading;
using System.Threading.Tasks;
using Backend.Application.Brands.Services;
using Backend.Application.Common.Models;
using MediatR;

namespace Backend.Application.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommand : IRequest<ApiResult<string>>
    {
        public DeleteBrandCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

    public class DeleteBrandHandler : IRequestHandler<DeleteBrandCommand, ApiResult<string>>
    {
        private readonly IBrandService _brandService;

        public DeleteBrandHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<ApiResult<string>> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            return await _brandService.DeleteAsync(request.Id);
        }
    }
}
