using System;
using System.Threading.Tasks;
using Backend.Repository.Brand;
using Backend.Repository.Product;
using Backend.Repository.ProductPhoto;
using Backend.Repository.User;

namespace Backend.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IBrandRepository Brands { get; }
        IProductRepository Products { get; }
        IProductPhotoRepository ProductPhotos { get; }
        Task<int> SaveChangesAsync();
    }
}
