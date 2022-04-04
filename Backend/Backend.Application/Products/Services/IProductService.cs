using Backend.Application.Common.Models;
using Backend.Application.Products.Models;
using Backend.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Application.Products.Services
{
    public interface IProductService
    {
        Task<ApiResult<string>> CreateAsync(CreateProductResource request);
        Task<ApiResult<string>> UpdateAsync(int id, UpdateProductResource update);
        Task<ApiResult<string>> DeleteAsync(int productId);
        Task<ApiResult<Product>> GetProductByIdAsync(int productId);
        Task<ApiResult<List<Product>>> GetAllProductAsync();
        Task<ApiResult<string>> DisableAsync(int productId);
        Task<ApiResult<string>> EnableAsync(int productId);
    }
}
