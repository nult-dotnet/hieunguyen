using System.Threading.Tasks;
using Backend.Data.EF;
using Backend.Repository.Brand;
using Backend.Repository.User;

namespace Backend.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BackendDbContext _context;
        private IUserRepository _users;
        private IBrandRepository _brands;

        public UnitOfWork(BackendDbContext context)
        {
            _context = context;
        }

        public IUserRepository Users => _users ??= new UserRepository(_context);
        public IBrandRepository Brands => _brands ??= new BrandRepository(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
