using System.Collections.Generic;

namespace Backend.Data.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double TotalRate { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
