using Backend.Data.EF;
using Backend.Repository.Generic;

namespace Backend.Repository.ProductPhoto
{
    public class ProductPhotoRepository : GenericRepository<Data.Entities.ProductPhoto>, IProductPhotoRepository
    {
        public ProductPhotoRepository(BackendDbContext context) : base(context)
        {
        }
    }
}
