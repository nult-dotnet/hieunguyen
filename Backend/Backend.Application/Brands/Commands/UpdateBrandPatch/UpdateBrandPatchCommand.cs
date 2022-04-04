using System.Threading;
using System.Threading.Tasks;
using Backend.Application.Brands.Services;
using Backend.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace Backend.Application.Brands.Commands.UpdateBrandPatch
{
    public class UpdateBrandPatchCommand : IRequest<ApiResult<string>>
    {
        public UpdateBrandPatchCommand(int id, JsonPatchDocument jsonPatchDocument)
        {
            Id = id;
            JsonPatchDocument = jsonPatchDocument;
        }

        public int Id { get; set; }
        public JsonPatchDocument JsonPatchDocument { get; set; }
    }

    public class UpdateBrandPatchHandler: IRequestHandler<UpdateBrandPatchCommand, ApiResult<string>>
    {
        private readonly IBrandService _brandService;

        public UpdateBrandPatchHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<ApiResult<string>> Handle(UpdateBrandPatchCommand request, CancellationToken cancellationToken)
        {
            return await _brandService.UpdatePatchAsync(request.Id, request.JsonPatchDocument);
        }
    }
}
