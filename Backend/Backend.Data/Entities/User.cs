using System;
using System.Collections.Generic;
using Backend.Data.Enums;
using Microsoft.AspNetCore.Identity;

namespace Backend.Data.Entities
{
    public class User : IdentityUser<int>
    {
        public string FirstMiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public UserStatus Status { get; set; }
        public Gender Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public ICollection<Brand> Brands { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<UserClaim> UserClaims { get; set; }
        public ICollection<UserLogin> UserLogins { get; set; }
        public ICollection<UserToken> UserTokens { get; set; }
    }
}
