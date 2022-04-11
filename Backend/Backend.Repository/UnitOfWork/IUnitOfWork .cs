using System;
using System.Threading.Tasks;
using Backend.Repository.Brand;
using Backend.Repository.Product;
using Backend.Repository.ProductPhoto;
using Backend.Repository.User;
using Backend.Repository.UserRole;

namespace Backend.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IUserRoleRepository UserRoles { get; }
        IBrandRepository Brands { get; }
        IProductRepository Products { get; }
        IProductPhotoRepository ProductPhotos { get; }
        Task<int> SaveChangesAsync();
    }
}
