using System;
using Backend.Data.Entities;
using Backend.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserName = "hieunguyen",
                    PasswordHash = hasher.HashPassword(null, "Hieu@123"),
                    FirstMiddleName = "Nguyễn Trung",
                    LastName = "Hiếu",
                    Address = "KTX Cỏ May, khu phố 6, phường Linh Trung, quận Thủ Đức, TP.HCM",
                    Status = 0,
                    Gender = Gender.MALE,
                    Email = "hieutanmy321@gmail.com",
                    PhoneNumber = "0965924083",
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    NormalizedUserName = "HIEUNGUYEN",
                    NormalizedEmail = "HIEUTANMY321@GMAIL.COM"
                },
                new User
                {
                    Id = 2,
                    UserName = "hieuvo",
                    PasswordHash = hasher.HashPassword(null, "Hieu@123"),
                    FirstMiddleName = "Võ Trọng",
                    LastName = "Hiếu",
                    Address = "KTX Cỏ May, khu phố 6, phường Linh Trung, quận Thủ Đức, TP.HCM",
                    Status = 0,
                    Gender = Gender.MALE,
                    Email = "hieuvo@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    NormalizedUserName = "HIEUVO",
                    NormalizedEmail = "HIEUVO@GMAIL.COM"
                },
                new User
                {
                    Id = 3,
                    UserName = "datle",
                    PasswordHash = hasher.HashPassword(null, "Hieu@123"),
                    FirstMiddleName = "Lê Tấn",
                    LastName = "Đạt",
                    Address = "KTX Cỏ May, khu phố 6, phường Linh Trung, quận Thủ Đức, TP.HCM",
                    Status = 0,
                    Gender = Gender.MALE,
                    Email = "dat@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    NormalizedUserName = "DATLE",
                    NormalizedEmail = "DAT@GMAIL.COM"
                }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    Description = "Quản trị viên"
                },
                new Role
                {
                    Id = 2,
                    Name = "Partner",
                    NormalizedName = "PARTNER",
                    Description = "Người bán hàng"
                },
                new Role
                {
                    Id = 3,
                    Name = "User",
                    NormalizedName = "USER",
                    Description = "Người dùng đã đăng ký"
                }
            );

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    UserId = 1,
                    RoleId = 1
                },
                new UserRole
                {
                    UserId = 2,
                    RoleId = 2
                },
                new UserRole
                {
                    UserId = 2,
                    RoleId = 3
                }
            );
            modelBuilder.Entity<ProductType>().HasData(
                new ProductType
                {
                    Id = 1,
                    Name = "Thời Trang Nam",
                    Status = true
                },
                new ProductType
                {
                    Id = 2,
                    Name = "Thời Trang Nữ",
                    Status = true
                },
                new ProductType
                {
                    Id = 3,
                    Name = "Điện Thoại - Phụ Kiện",
                    Status = true
                },
                new ProductType
                {
                    Id = 4,
                    Name = "Máy Tính - Laptop",
                    Status = true
                },
                new ProductType
                {
                    Id = 5,
                    Name = "Đồng Hồ",
                    Status = true
                }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Alias = "laptop-dell",
                    CreatedBy = "hieunguyen",
                    CreatedDate = DateTime.Now,
                    ModifiedBy = null,
                    ModifiedDate = null,
                    Name = "Laptop Dell",
                    ProductTypeId = 4
                },
                new Category
                {
                    Id = 2,
                    Alias = "laptop-macbook",
                    CreatedBy = "hieunguyen",
                    CreatedDate = DateTime.Now,
                    ModifiedBy = null,
                    ModifiedDate = null,
                    Name = "Laptop Macbook",
                    ProductTypeId = 4
                },
                new Category
                {
                    Id = 3,
                    Alias = "laptop-hp",
                    CreatedBy = "hieunguyen",
                    CreatedDate = DateTime.Now,
                    ModifiedBy = null,
                    ModifiedDate = null,
                    Name = "Laptop HP",
                    ProductTypeId = 4
                },
                new Category
                {
                    Id = 4,
                    Alias = "laptop-acer",
                    CreatedBy = "hieunguyen",
                    CreatedDate = DateTime.Now,
                    ModifiedBy = null,
                    ModifiedDate = null,
                    Name = "Laptop Acer",
                    ProductTypeId = 4
                },
                new Category
                {
                    Id = 5,
                    Alias = "laptop-asus",
                    CreatedBy = "hieunguyen",
                    CreatedDate = DateTime.Now,
                    ModifiedBy = null,
                    ModifiedDate = null,
                    Name = "Laptop Asus",
                    ProductTypeId = 4
                }
            );
        }
    }
}