using System;
using Backend.Application.Brands.Models;
using Backend.Data.Entities;

namespace Backend.Application.Brands.Extensions
{
    public static class BrandExtensions
    {
        public static void Map(this Brand brand, UpdateBrandResource update)
        {
            brand.Name = update.Name;
            brand.Description = update.Description;
            brand.Address = update.Address;
            brand.PhoneNumber = update.PhoneNumber;
            brand.Status = update.Status;
        }
    }
}
