using Backend.Data.EF;
using Backend.Repository.Generic;

namespace Backend.Repository.Brand
{
    public class BrandRepository : GenericRepository<Data.Entities.Brand>, IBrandRepository
    {
        public BrandRepository(BackendDbContext context) : base(context)
        {
        }
    }
}
