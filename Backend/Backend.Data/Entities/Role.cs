using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Data.Entities
{
    [BsonIgnoreExtraElements]
    public class Role
    {
        public int ModelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}
