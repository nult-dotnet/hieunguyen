using Backend.Application.Brands.Models;
using Backend.Application.Brands.Services;
using Backend.Application.Common.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Backend.Data.Entities;

namespace Backend.Application.Brands.Commands.CreateBrand
{
    public class CreateBrandCommand : IRequest<ApiResult<Brand>>
    {
        public CreateBrandCommand(CreateBrandResource createBrandResource)
        {
            CreateBrandResource = createBrandResource;
        }

        public CreateBrandResource CreateBrandResource { get; set; }
    }

    public class CreateBrandHandler: IRequestHandler<CreateBrandCommand, ApiResult<Brand>>
    {
        private readonly IBrandService _brandService;

        public CreateBrandHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<ApiResult<Brand>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            return await _brandService.CreateAsync(request.CreateBrandResource);
        }
    }
}
