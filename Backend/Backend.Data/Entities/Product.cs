using System;
using Backend.Data.Enums;

namespace Backend.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public int GoodsReceipt { get; set; }
        public int Inventory { get; set; }
        public ProductStatus Status { get; set; }
        public int CategoryId { get; set; }
        public string Alias { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int BrandId { get; set; }

        public Category Category { get; set; }
        public Brand Brand { get; set; }
    }
}
