using Backend.Data.EF;
using Backend.Repository.Generic;

namespace Backend.Repository.Product
{
    public class ProductRepository : GenericRepository<Data.Entities.Product>, IProductRepository
    {
        public ProductRepository(BackendDbContext context) : base(context)
        {
        }
    }
}
