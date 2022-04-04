using System;
using System.Threading.Tasks;
using Backend.Repository.Brand;
using Backend.Repository.User;

namespace Backend.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IBrandRepository Brands { get; }
        Task<int> SaveChangesAsync();
    }
}
