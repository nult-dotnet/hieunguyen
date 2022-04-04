using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Backend.Application.Brands.Services;
using Backend.Application.Common.Models;
using Backend.Data.Entities;
using MediatR;

namespace Backend.Application.Brands.Queries.GetAllBrand
{
    public class GetAllBrandQuery : IRequest<ApiResult<List<Brand>>>
    {
    }

    public class GetAllBrandHandler : IRequestHandler<GetAllBrandQuery, ApiResult<List<Brand>>>
    {
        private readonly IBrandService _brandService;

        public GetAllBrandHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<ApiResult<List<Brand>>> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
        {
            return await _brandService.GetAllAsync();
        }
    }
}
