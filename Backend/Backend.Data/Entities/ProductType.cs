using System.Collections.Generic;

namespace Backend.Data.Entities
{
    public class ProductType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
