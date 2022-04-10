using Backend.Application.Brands.Models;
using Backend.Application.Common.Models;
using Backend.Data.Entities;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Application.Brands.Services
{
    public interface IBrandService
    {
        Task<ApiResult<List<Brand>>> GetAllAsync();
        Task<ApiResult<Brand>> GetByIdAsync(int id);
        Task<ApiResult<Brand>> GetByOwnerUser();
        Task<ApiResult<Brand>> CreateAsync(CreateBrandResource resource);
        Task<ApiResult<string>> UpdatePatchAsync(int id, JsonPatchDocument patchDocument);
        Task<ApiResult<Brand>> UpdateAsync(int id, UpdateBrandResource resource);
        Task<ApiResult<string>> DeleteAsync(int id);
    }
}
