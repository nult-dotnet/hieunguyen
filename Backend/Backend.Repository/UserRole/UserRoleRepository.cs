using Backend.Data.EF;
using Backend.Repository.Generic;

namespace Backend.Repository.UserRole
{
    public class UserRoleRepository : GenericRepository<Data.Entities.UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(BackendDbContext context) : base(context)
        {
        }
    }
}
