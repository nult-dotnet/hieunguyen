using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Backend.Infrastructure.FileImage
{
    public interface IStorageService
    { 
        Task<string> SaveFile(string path, IFormFile image);

        Task DeleteFileAsync(string filePath);

        string CreateProductPath(int cateId, string productName);

        void ChangeNameFolder(string fromFoler, string toFolder);
    }
}
