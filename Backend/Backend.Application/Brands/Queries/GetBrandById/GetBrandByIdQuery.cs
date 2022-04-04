using System.Threading;
using System.Threading.Tasks;
using Backend.Application.Brands.Services;
using Backend.Application.Common.Models;
using Backend.Data.Entities;
using MediatR;

namespace Backend.Application.Brands.Queries.GetBrandById
{
    public class GetBrandByIdQuery : IRequest<ApiResult<Brand>>
    {
        public GetBrandByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

    public class GetBrandByIdHandler : IRequestHandler<GetBrandByIdQuery, ApiResult<Brand>>
    {
        private readonly IBrandService _brandService;

        public GetBrandByIdHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<ApiResult<Brand>> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            return await _brandService.GetByIdAsync(request.Id);
        }
    }
}
