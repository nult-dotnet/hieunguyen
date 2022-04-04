using System.ComponentModel.DataAnnotations;

namespace Backend.Application.Brands.Models
{
    public class CreateBrandResource
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int Status { get; set; }
    }
}
