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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<double>("TotalRate")
                        .HasColumnType("double precision");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("Backend.Data.Entities.Category", b =>
                {
                    b.Property<int>("Id")
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

                    b.HasKey("Id");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Alias = "laptop-dell",
                            CreatedBy = "hieunguyen",
                            CreatedDate = new DateTime(2022, 4, 4, 6, 41, 0, 428, DateTimeKind.Local).AddTicks(6639),
                            Name = "Laptop Dell",
                            ProductTypeId = 4
                        },
                        new
                        {
                            Id = 2,
                            Alias = "laptop-macbook",
                            CreatedBy = "hieunguyen",
                            CreatedDate = new DateTime(2022, 4, 4, 6, 41, 0, 429, DateTimeKind.Local).AddTicks(3587),
                            Name = "Laptop Macbook",
                            ProductTypeId = 4
                        },
                        new
                        {
                            Id = 3,
                            Alias = "laptop-hp",
                            CreatedBy = "hieunguyen",
                            CreatedDate = new DateTime(2022, 4, 4, 6, 41, 0, 429, DateTimeKind.Local).AddTicks(3665),
                            Name = "Laptop HP",
                            ProductTypeId = 4
                        },
                        new
                        {
                            Id = 4,
                            Alias = "laptop-acer",
                            CreatedBy = "hieunguyen",
                            CreatedDate = new DateTime(2022, 4, 4, 6, 41, 0, 429, DateTimeKind.Local).AddTicks(3669),
                            Name = "Laptop Acer",
                            ProductTypeId = 4
                        },
                        new
                        {
                            Id = 5,
                            Alias = "laptop-asus",
                            CreatedBy = "hieunguyen",
                            CreatedDate = new DateTime(2022, 4, 4, 6, 41, 0, 429, DateTimeKind.Local).AddTicks(3671),
                            Name = "Laptop Asus",
                            ProductTypeId = 4
                        });
                });

            modelBuilder.Entity("Backend.Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
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

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Backend.Data.Entities.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("ProductType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Thời Trang Nam",
                            Status = true
                        },
                        new
                        {
                            Id = 2,
                            Name = "Thời Trang Nữ",
                            Status = true
                        },
                        new
                        {
                            Id = 3,
                            Name = "Điện Thoại - Phụ Kiện",
                            Status = true
                        },
                        new
                        {
                            Id = 4,
                            Name = "Máy Tính - Laptop",
                            Status = true
                        },
                        new
                        {
                            Id = 5,
                            Name = "Đồng Hồ",
                            Status = true
                        });
                });

            modelBuilder.Entity("Backend.Data.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(20)")
                        .HasMaxLength(20);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "6ce40991-c1ee-4e4a-991f-9ad752b397ad",
                            Description = "Quản trị viên",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "2307b989-02b3-4b50-9e05-67920bbd9bcf",
                            Description = "Người bán hàng",
                            Name = "Partner",
                            NormalizedName = "PARTNER"
                        },
                        new
                        {
                            Id = 3,
                            ConcurrencyStamp = "b16e17b3-f2b1-467b-b0bb-38957cb7c6e1",
                            Description = "Người dùng đã đăng ký",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Backend.Data.Entities.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaim");
                });

            modelBuilder.Entity("Backend.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 4)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("Address")
                        .HasColumnType("character varying(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("Date");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("Date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstMiddleName")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("Date");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("character varying(11)")
                        .HasMaxLength(11);

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            Address = "KTX Cỏ May, khu phố 6, phường Linh Trung, quận Thủ Đức, TP.HCM",
                            ConcurrencyStamp = "f1032ebc-8c66-423a-821a-7bb5d0a047fb",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "hieutanmy321@gmail.com",
                            EmailConfirmed = false,
                            FirstMiddleName = "Nguyễn Trung",
                            Gender = 0,
                            LastName = "Hiếu",
                            LockoutEnabled = false,
                            NormalizedEmail = "HIEUTANMY321@GMAIL.COM",
                            NormalizedUserName = "HIEUNGUYEN",
                            PasswordHash = "AQAAAAEAACcQAAAAEK5u/qTFt2BLO5lEBsamvlNWPC1xGaU3GAgYUxA6aRVwMfuP4MzuLReYl8g/3JjHlQ==",
                            PhoneNumber = "0965924083",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "41aeda8a-8d0d-4822-ae22-1bc1261ac706",
                            Status = 0,
                            TwoFactorEnabled = false,
                            UserName = "hieunguyen"
                        },
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            Address = "KTX Cỏ May, khu phố 6, phường Linh Trung, quận Thủ Đức, TP.HCM",
                            ConcurrencyStamp = "b0c0f70e-0724-4cd7-905b-bf7eb9fe3d01",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "hieuvo@gmail.com",
                            EmailConfirmed = false,
                            FirstMiddleName = "Võ Trọng",
                            Gender = 0,
                            LastName = "Hiếu",
                            LockoutEnabled = false,
                            NormalizedEmail = "HIEUVO@GMAIL.COM",
                            NormalizedUserName = "HIEUVO",
                            PasswordHash = "AQAAAAEAACcQAAAAED5Z31ma4cjYwNXccmhNTtMoUjwtvwQwLTYWISOVP8A1lQkAsJ/RgVrCIBquoskUMw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "3cec666e-d757-49b0-ba57-e66987368878",
                            Status = 0,
                            TwoFactorEnabled = false,
                            UserName = "hieuvo"
                        },
                        new
                        {
                            Id = 3,
                            AccessFailedCount = 0,
                            Address = "KTX Cỏ May, khu phố 6, phường Linh Trung, quận Thủ Đức, TP.HCM",
                            ConcurrencyStamp = "19c34c01-41cf-45d6-a6fc-bafcb88ccfde",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "dat@gmail.com",
                            EmailConfirmed = false,
                            FirstMiddleName = "Lê Tấn",
                            Gender = 0,
                            LastName = "Đạt",
                            LockoutEnabled = false,
                            NormalizedEmail = "DAT@GMAIL.COM",
                            NormalizedUserName = "DATLE",
                            PasswordHash = "AQAAAAEAACcQAAAAEKjM//26CN8axGLFGo2emc8dfCx9efMqCN4othkg0gBhCviuTuMApjV0nM+nFMpc0g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "12dc50ae-bbe3-4c8f-9263-81edec9dae6e",
                            Status = 0,
                            TwoFactorEnabled = false,
                            UserName = "datle"
                        });
                });

            modelBuilder.Entity("Backend.Data.Entities.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaim");
                });

            modelBuilder.Entity("Backend.Data.Entities.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogin");
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
                            RoleId = 2,
                            UserId = 2
                        },
                        new
                        {
                            RoleId = 3,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("Backend.Data.Entities.UserToken", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserToken");
                });

            modelBuilder.Entity("Backend.Data.Entities.Brand", b =>
                {
                    b.HasOne("Backend.Data.Entities.User", "User")
                        .WithMany("Brands")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
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

            modelBuilder.Entity("Backend.Data.Entities.RoleClaim", b =>
                {
                    b.HasOne("Backend.Data.Entities.Role", "Role")
                        .WithMany("RoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Data.Entities.UserClaim", b =>
                {
                    b.HasOne("Backend.Data.Entities.User", "User")
                        .WithMany("UserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Data.Entities.UserLogin", b =>
                {
                    b.HasOne("Backend.Data.Entities.User", "User")
                        .WithMany("UserLogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
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

            modelBuilder.Entity("Backend.Data.Entities.UserToken", b =>
                {
                    b.HasOne("Backend.Data.Entities.User", "User")
                        .WithMany("UserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
