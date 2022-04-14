using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Data.Entities
{
    [BsonIgnoreExtraElements]
    public class ProductPhoto
    {
        public int ModelId { get; set; }

        public int ProductId { get; set; }

        public string Url { get; set; }

        public bool IsDefault { get; set; }

        public Product Product { get; set; }
    }
}
