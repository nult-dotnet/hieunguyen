using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Data.Entities
{
    [BsonIgnoreExtraElements]
    public class Category
    {
        public int ModelId { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public int ProductTypeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public ICollection<Product> Products { get; set; }
        public ProductType ProductType { get; set; }
    }
}
