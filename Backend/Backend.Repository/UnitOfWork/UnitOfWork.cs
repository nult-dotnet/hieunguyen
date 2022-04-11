using System.Threading.Tasks;
using Backend.Data.EF;
using Backend.Repository.Brand;
using Backend.Repository.Product;
using Backend.Repository.ProductPhoto;
using Backend.Repository.User;
using Backend.Repository.UserRole;

namespace Backend.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BackendDbContext _context;
        private IUserRepository _users;
        private IBrandRepository _brands;
        private IProductRepository _products;
        private IProductPhotoRepository _productPhotos;
        private IUserRoleRepository _userRoles;

        public UnitOfWork(BackendDbContext context)
        {
            _context = context;
        }

        public IUserRepository Users => _users ??= new UserRepository(_context);
        public IUserRoleRepository UserRoles => _userRoles ??= new UserRoleRepository(_context);
        public IBrandRepository Brands => _brands ??= new BrandRepository(_context);
        public IProductRepository Products => _products ??= new ProductRepository(_context);
        public IProductPhotoRepository ProductPhotos => _productPhotos ??= new ProductPhotoRepository(_context);

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
