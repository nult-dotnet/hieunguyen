using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Backend.Data.Enums;
using Microsoft.AspNetCore.Http;

namespace Backend.Application.Products.Models
{
    public class CreateProductResource
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Detail { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int GoodsReceipt { get; set; }

        public ProductStatus Status { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int BrandId { get; set; }

        [Required]
        public List<IFormFile> ThumbnailImages { get; set; }
    }
}
