using Backend.Data.EF;
using Backend.Repository.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Repository.UnitOfWork
{
    public class UnitOfWorkMongo : IUnitOfWork
    {
        private readonly IMongoDbContext _context;
        private Dictionary<string, object> _repositories;

        public UnitOfWorkMongo(IMongoDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangeAsync();
        }

        public void CreateTransaction()
        {
        }

        public void Commit()
        {
        }

        public void Rollback()
        {
        }

        public object Context => _context;

        public class Repository<T> : GenericRepositoryMongo<T> where T : class
        {
            public Repository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
        }
    }
}
