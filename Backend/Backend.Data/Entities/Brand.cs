using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Data.Entities
{
    [BsonIgnoreExtraElements]
    public class Brand
    {
        public int ModelId { get; set; }
        public string Name { get; set; }
        public double TotalRate { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }
        public int UserId { get; set; }
        public string PhoneNumber { get; set; }
        public User User { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
