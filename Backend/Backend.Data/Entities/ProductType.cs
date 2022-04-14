using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Data.Entities
{
    [BsonIgnoreExtraElements]
    public class ProductType
    {
        public int ModelId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
