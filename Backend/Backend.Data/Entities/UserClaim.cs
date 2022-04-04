using Microsoft.AspNetCore.Identity;

namespace Backend.Data.Entities
{
    public class UserClaim : IdentityUserClaim<int>
    {
        public User User { get; set; }
    }
}
