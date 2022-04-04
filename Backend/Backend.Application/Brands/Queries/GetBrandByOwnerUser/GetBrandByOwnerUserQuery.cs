using System.Threading;
using System.Threading.Tasks;
using Backend.Application.Brands.Services;
using Backend.Application.Common.Models;
using Backend.Data.Entities;
using MediatR;

namespace Backend.Application.Brands.Queries.GetBrandByOwnerUser
{
    public class GetBrandByOwnerUserQuery : IRequest<ApiResult<Brand>>
    {
    }

    public class GetBrandByOwnerUserHandler : IRequestHandler<GetBrandByOwnerUserQuery, ApiResult<Brand>>
    {
        private readonly IBrandService _brandService;

        public GetBrandByOwnerUserHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<ApiResult<Brand>> Handle(GetBrandByOwnerUserQuery request, CancellationToken cancellationToken)
        {
            return await _brandService.GetByOwnerUser();
        }
    }
}
