using Microsoft.AspNetCore.Identity;

namespace Backend.Data.Entities
{
    public class UserLogin: IdentityUserLogin<int>
    {
        public User User { get; set; }
    }
}
