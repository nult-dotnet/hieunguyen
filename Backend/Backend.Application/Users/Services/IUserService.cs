using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Application.Common.Models;
using Backend.Application.Users.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace Backend.Application.Users.Services
{
    public interface IUserService
    {
        Task<ApiResult<string>> CreateAsync(CreateUserResource request);
        Task<ApiResult<UserVm>> GetByIdAsync(int userId);
        Task<ApiResult<List<UserVm>>> GetAllAsync();
        Task<ApiResult<string>> UpdateAsync(int id, UpdateUserResource request);
        Task<ApiResult<string>> DeleteAsync(int userId);
        Task<ApiResult<string>> UpdatePatchAsync(int id, JsonPatchDocument request);
    }
}
