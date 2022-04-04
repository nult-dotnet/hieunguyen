using System;
using Backend.Application.Products.Models;
using Backend.Data.Entities;

namespace Backend.Application.Products.Extensions
{
    public static class ProductExtensions
    {
        public static void Map(this Product product, UpdateProductResource update)
        {
            product.Name = update.Name;
            product.Price = update.Price;
            product.Detail = update.Detail;
            product.Description = update.Description;
            product.GoodsReceipt = update.GoodsReceipt;
            product.Inventory = update.Inventory;
            product.Status = update.Status;
            product.CategoryId = update.CategoryId;
            product.ModifiedDate = DateTime.Now;
        }
    }
}
