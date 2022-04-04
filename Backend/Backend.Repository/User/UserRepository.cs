using Backend.Data.EF;
using Backend.Repository.Generic;

namespace Backend.Repository.User
{
    public class UserRepository : GenericRepository<Data.Entities.User>, IUserRepository
    {
        public UserRepository(BackendDbContext context) : base(context)
        {
        }
    }
}
