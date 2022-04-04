using Microsoft.AspNetCore.Identity;

namespace Backend.Data.Entities
{
    public class UserToken: IdentityUserToken<int>
    {
        public User User { get; set; }
    }
}
