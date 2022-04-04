using Microsoft.AspNetCore.Identity;

namespace Backend.Data.Entities
{
    public class RoleClaim : IdentityRoleClaim<int>
    {
        public Role Role { get; set; }
    }
}
