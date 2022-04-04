using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Backend.Data.Enums;

namespace Backend.Application.Products.Models
{
    public class UpdateProductResource
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

        [Required]
        public int Inventory { get; set; }

        public ProductStatus Status { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
