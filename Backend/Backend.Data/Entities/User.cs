using System;
using System.Collections.Generic;
using Backend.Data.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Data.Entities
{
    [BsonIgnoreExtraElements]
    public class User
    {
        public int ModelId { get; set; }
        public string UserName { get; set; }
        public virtual string PasswordHash { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
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
    }
}
