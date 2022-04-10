using Backend.Application.Brands.Models;
using Backend.Application.Brands.Services;
using Backend.Application.Common.Models;
using Backend.Data.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Brands.Commands.UpdateBrand
{
    public class UpdateBrandComand : IRequest<ApiResult<Brand>>
    {
        public UpdateBrandComand(int id, UpdateBrandResource updateBrandResource)
        {
            UpdateBrandResource = updateBrandResource;
            Id = id;
        }

        public int Id { get; set; }
        public UpdateBrandResource UpdateBrandResource { get; set; }
    }

    public class UpdateCommandHandler : IRequestHandler<UpdateBrandComand, ApiResult<Brand>>
    {
        private readonly IBrandService _brandService;

        public UpdateCommandHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<ApiResult<Brand>> Handle(UpdateBrandComand request, CancellationToken cancellationToken)
        {
            return await _brandService.UpdateAsync(request.Id, request.UpdateBrandResource);
        }
    }
}
