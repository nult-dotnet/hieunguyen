using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Backend.PostgresSqlMigrations.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    ModelId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.ModelId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    ModelId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ModelId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ModelId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 11, nullable: true),
                    FirstMiddleName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    Address = table.Column<string>(maxLength: 500, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Birthday = table.Column<DateTime>(type: "Date", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "Date", nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ModelId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ModelId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Alias = table.Column<string>(maxLength: 100, nullable: false),
                    ProductTypeId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "Date", nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ModelId);
                    table.ForeignKey(
                        name: "FK_Category_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductType",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    ModelId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    TotalRate = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.ModelId);
                    table.ForeignKey(
                        name: "FK_Brand_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ModelId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Detail = table.Column<string>(nullable: false),
                    GoodsReceipt = table.Column<int>(nullable: false),
                    Inventory = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Alias = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "Date", nullable: true),
                    BrandId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ModelId);
                    table.ForeignKey(
                        name: "FK_Product_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductPhoto",
                columns: table => new
                {
                    ModelId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPhoto", x => x.ModelId);
                    table.ForeignKey(
                        name: "FK_ProductPhoto_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "ModelId", "Name", "Status" },
                values: new object[,]
                {
                    { 1, "Thời Trang Nam", true },
                    { 2, "Thời Trang Nữ", true },
                    { 3, "Điện Thoại - Phụ Kiện", true },
                    { 4, "Máy Tính - Laptop", true },
                    { 5, "Đồng Hồ", true }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "ModelId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Quản trị viên", "Admin" },
                    { 2, "Người bán hàng", "Partner" },
                    { 3, "Người dùng đã đăng ký", "User" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ModelId", "Address", "Birthday", "CreatedBy", "CreatedDate", "Email", "FirstMiddleName", "Gender", "LastName", "ModifiedBy", "ModifiedDate", "PasswordHash", "PhoneNumber", "Status", "UserName" },
                values: new object[,]
                {
                    { 1, "KTX Cỏ May, khu phố 6, phường Linh Trung, quận Thủ Đức, TP.HCM", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "hieutanmy321@gmail.com", "Nguyễn Trung", 0, "Hiếu", null, null, "9761509327fd5beca49c1c588df59ef8dc957a3e4ef6870190589455e8c60045", "0965924083", 0, "hieunguyen" },
                    { 2, "KTX Cỏ May, khu phố 6, phường Linh Trung, quận Thủ Đức, TP.HCM", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "hieuvo@gmail.com", "Võ Trọng", 0, "Hiếu", null, null, "9761509327fd5beca49c1c588df59ef8dc957a3e4ef6870190589455e8c60045", null, 0, "hieuvo" },
                    { 3, "KTX Cỏ May, khu phố 6, phường Linh Trung, quận Thủ Đức, TP.HCM", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "dat@gmail.com", "Lê Tấn", 0, "Đạt", null, null, "9761509327fd5beca49c1c588df59ef8dc957a3e4ef6870190589455e8c60045", null, 0, "datle" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "ModelId", "Alias", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Name", "ProductTypeId" },
                values: new object[,]
                {
                    { 1, "laptop-dell", "hieunguyen", new DateTime(2022, 4, 13, 21, 48, 12, 765, DateTimeKind.Local).AddTicks(9085), null, null, "Laptop Dell", 4 },
                    { 2, "laptop-macbook", "hieunguyen", new DateTime(2022, 4, 13, 21, 48, 12, 766, DateTimeKind.Local).AddTicks(6025), null, null, "Laptop Macbook", 4 },
                    { 3, "laptop-hp", "hieunguyen", new DateTime(2022, 4, 13, 21, 48, 12, 766, DateTimeKind.Local).AddTicks(6080), null, null, "Laptop HP", 4 },
                    { 4, "laptop-acer", "hieunguyen", new DateTime(2022, 4, 13, 21, 48, 12, 766, DateTimeKind.Local).AddTicks(6083), null, null, "Laptop Acer", 4 },
                    { 5, "laptop-asus", "hieunguyen", new DateTime(2022, 4, 13, 21, 48, 12, 766, DateTimeKind.Local).AddTicks(6085), null, null, "Laptop Asus", 4 }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 2 },
                    { 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brand_UserId",
                table: "Brand",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ProductTypeId",
                table: "Category",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandId",
                table: "Product",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPhoto_ProductId",
                table: "ProductPhoto",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductPhoto");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ProductType");
        }
    }
}
