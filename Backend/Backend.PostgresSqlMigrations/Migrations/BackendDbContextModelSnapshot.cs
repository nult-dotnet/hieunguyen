﻿// <auto-generated />
using System;
using Backend.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Backend.PostgresSqlMigrations.Migrations
{
    [DbContext(typeof(BackendDbContext))]
    partial class BackendDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Backend.Data.Entities.Brand", b =>
                {
                    b.Property<int>("ModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(20)")
                        .HasMaxLength(20);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("character varying(11)")
                        .HasMaxLength(11);

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<double>("TotalRate")
                        .HasColumnType("double precision");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("ModelId");

                    b.HasIndex("UserId");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("Backend.Data.Entities.Category", b =>
                {
                    b.Property<int>("ModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("Date");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("Date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("integer");

                    b.HasKey("ModelId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            ModelId = 1,
                            Alias = "laptop-dell",
                            CreatedBy = "hieunguyen",
                            CreatedDate = new DateTime(2022, 4, 13, 21, 48, 12, 765, DateTimeKind.Local).AddTicks(9085),
                            Name = "Laptop Dell",
                            ProductTypeId = 4
                        },
                        new
                        {
                            ModelId = 2,
                            Alias = "laptop-macbook",
                            CreatedBy = "hieunguyen",
                            CreatedDate = new DateTime(2022, 4, 13, 21, 48, 12, 766, DateTimeKind.Local).AddTicks(6025),
                            Name = "Laptop Macbook",
                            ProductTypeId = 4
                        },
                        new
                        {
                            ModelId = 3,
                            Alias = "laptop-hp",
                            CreatedBy = "hieunguyen",
                            CreatedDate = new DateTime(2022, 4, 13, 21, 48, 12, 766, DateTimeKind.Local).AddTicks(6080),
                            Name = "Laptop HP",
                            ProductTypeId = 4
                        },
                        new
                        {
                            ModelId = 4,
                            Alias = "laptop-acer",
                            CreatedBy = "hieunguyen",
                            CreatedDate = new DateTime(2022, 4, 13, 21, 48, 12, 766, DateTimeKind.Local).AddTicks(6083),
                            Name = "Laptop Acer",
                            ProductTypeId = 4
                        },
                        new
                        {
                            ModelId = 5,
                            Alias = "laptop-asus",
                            CreatedBy = "hieunguyen",
                            CreatedDate = new DateTime(2022, 4, 13, 21, 48, 12, 766, DateTimeKind.Local).AddTicks(6085),
                            Name = "Laptop Asus",
                            ProductTypeId = 4
                        });
                });

            modelBuilder.Entity("Backend.Data.Entities.Product", b =>
                {
                    b.Property<int>("ModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("BrandId")
                        .HasColumnType("integer");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("Date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("GoodsReceipt")
                        .HasColumnType("integer");

                    b.Property<int>("Inventory")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("Date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,0)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("ModelId");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Backend.Data.Entities.ProductPhoto", b =>
                {
                    b.Property<int>("ModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("IsDefault")
                        .HasColumnType("boolean");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("ModelId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductPhoto");
                });

            modelBuilder.Entity("Backend.Data.Entities.ProductType", b =>
                {
                    b.Property<int>("ModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.HasKey("ModelId");

                    b.ToTable("ProductType");

                    b.HasData(
                        new
                        {
                            ModelId = 1,
                            Name = "Thời Trang Nam",
                            Status = true
                        },
                        new
                        {
                            ModelId = 2,
                            Name = "Thời Trang Nữ",
                            Status = true
                        },
                        new
                        {
                            ModelId = 3,
                            Name = "Điện Thoại - Phụ Kiện",
                            Status = true
                        },
                        new
                        {
                            ModelId = 4,
                            Name = "Máy Tính - Laptop",
                            Status = true
                        },
                        new
                        {
                            ModelId = 5,
                            Name = "Đồng Hồ",
                            Status = true
                        });
                });

            modelBuilder.Entity("Backend.Data.Entities.Role", b =>
                {
                    b.Property<int>("ModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(20)")
                        .HasMaxLength(20);

                    b.HasKey("ModelId");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            ModelId = 1,
                            Description = "Quản trị viên",
                            Name = "Admin"
                        },
                        new
                        {
                            ModelId = 2,
                            Description = "Người bán hàng",
                            Name = "Partner"
                        },
                        new
                        {
                            ModelId = 3,
                            Description = "Người dùng đã đăng ký",
                            Name = "User"
                        });
                });

            modelBuilder.Entity("Backend.Data.Entities.User", b =>
                {
                    b.Property<int>("ModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 4)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("character varying(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("Date");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("Date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("FirstMiddleName")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("Date");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("character varying(11)")
                        .HasMaxLength(11);

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.HasKey("ModelId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            ModelId = 1,
                            Address = "KTX Cỏ May, khu phố 6, phường Linh Trung, quận Thủ Đức, TP.HCM",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "hieutanmy321@gmail.com",
                            FirstMiddleName = "Nguyễn Trung",
                            Gender = 0,
                            LastName = "Hiếu",
                            PasswordHash = "9761509327fd5beca49c1c588df59ef8dc957a3e4ef6870190589455e8c60045",
                            PhoneNumber = "0965924083",
                            Status = 0,
                            UserName = "hieunguyen"
                        },
                        new
                        {
                            ModelId = 2,
                            Address = "KTX Cỏ May, khu phố 6, phường Linh Trung, quận Thủ Đức, TP.HCM",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "hieuvo@gmail.com",
                            FirstMiddleName = "Võ Trọng",
                            Gender = 0,
                            LastName = "Hiếu",
                            PasswordHash = "9761509327fd5beca49c1c588df59ef8dc957a3e4ef6870190589455e8c60045",
                            Status = 0,
                            UserName = "hieuvo"
                        },
                        new
                        {
                            ModelId = 3,
                            Address = "KTX Cỏ May, khu phố 6, phường Linh Trung, quận Thủ Đức, TP.HCM",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "dat@gmail.com",
                            FirstMiddleName = "Lê Tấn",
                            Gender = 0,
                            LastName = "Đạt",
                            PasswordHash = "9761509327fd5beca49c1c588df59ef8dc957a3e4ef6870190589455e8c60045",
                            Status = 0,
                            UserName = "datle"
                        });
                });

            modelBuilder.Entity("Backend.Data.Entities.UserRole", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            UserId = 1
                        },
                        new
                        {
                            RoleId = 3,
                            UserId = 2
                        },
                        new
                        {
                            RoleId = 3,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("Backend.Data.Entities.Brand", b =>
                {
                    b.HasOne("Backend.Data.Entities.User", "User")
                        .WithMany("Brands")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Data.Entities.Category", b =>
                {
                    b.HasOne("Backend.Data.Entities.ProductType", "ProductType")
                        .WithMany("Categories")
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Data.Entities.Product", b =>
                {
                    b.HasOne("Backend.Data.Entities.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Backend.Data.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Data.Entities.ProductPhoto", b =>
                {
                    b.HasOne("Backend.Data.Entities.Product", "Product")
                        .WithMany("ProductPhotos")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Data.Entities.UserRole", b =>
                {
                    b.HasOne("Backend.Data.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Data.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
