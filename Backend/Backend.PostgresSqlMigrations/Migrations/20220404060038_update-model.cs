using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Backend.PostgresSqlMigrations.Migrations
{
    public partial class updatemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Brand",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductPhoto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPhoto_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 4, 4, 13, 0, 37, 534, DateTimeKind.Local).AddTicks(4042));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 4, 4, 13, 0, 37, 535, DateTimeKind.Local).AddTicks(1100));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 4, 4, 13, 0, 37, 535, DateTimeKind.Local).AddTicks(1167));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 4, 4, 13, 0, 37, 535, DateTimeKind.Local).AddTicks(1170));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 4, 4, 13, 0, 37, 535, DateTimeKind.Local).AddTicks(1173));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "6000a299-05fc-44d9-8c48-4616bf534396");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "a79b0f54-ba15-4edd-b3fb-a62c30a4baf5");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "25124888-51ac-48c5-a848-98258fc5b922");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2ebbe0d-9cec-4ed6-9a27-4b7cd7b7ed26", "AQAAAAEAACcQAAAAEE/PWJSDau0x8nmkZIkmbPvwIkzqQrBJv9p4ICnn9ljIGqYT8SYxAaqYWL1iYOz7RQ==", "e9a01f3a-6837-4bdc-982a-da9af3b556da" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16d91899-8e37-4337-b091-c1c5051fef22", "AQAAAAEAACcQAAAAEOUV4F05NqP36nzEUfKFnnC9UpQRyW8RO4BkM6iLRlxUGuI0B7JF2i/BmF/ZTvRyyw==", "1a161fc9-f548-42cf-8dc2-31d88d91605a" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "23805506-d569-495e-a021-9ec01cb3f6e4", "AQAAAAEAACcQAAAAEChF0hce0EX9bVQ7UtlhBN155O/eu2zEQcHroPziq3iP8XIedph6v/RILt/qJ5sYfA==", "6b6e19a4-f8e9-4552-99d8-0d2133c58ecd" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPhoto_ProductId",
                table: "ProductPhoto",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductPhoto");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Brand");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 4, 4, 6, 41, 0, 428, DateTimeKind.Local).AddTicks(6639));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 4, 4, 6, 41, 0, 429, DateTimeKind.Local).AddTicks(3587));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 4, 4, 6, 41, 0, 429, DateTimeKind.Local).AddTicks(3665));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 4, 4, 6, 41, 0, 429, DateTimeKind.Local).AddTicks(3669));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 4, 4, 6, 41, 0, 429, DateTimeKind.Local).AddTicks(3671));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "6ce40991-c1ee-4e4a-991f-9ad752b397ad");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "2307b989-02b3-4b50-9e05-67920bbd9bcf");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "b16e17b3-f2b1-467b-b0bb-38957cb7c6e1");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f1032ebc-8c66-423a-821a-7bb5d0a047fb", "AQAAAAEAACcQAAAAEK5u/qTFt2BLO5lEBsamvlNWPC1xGaU3GAgYUxA6aRVwMfuP4MzuLReYl8g/3JjHlQ==", "41aeda8a-8d0d-4822-ae22-1bc1261ac706" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0c0f70e-0724-4cd7-905b-bf7eb9fe3d01", "AQAAAAEAACcQAAAAED5Z31ma4cjYwNXccmhNTtMoUjwtvwQwLTYWISOVP8A1lQkAsJ/RgVrCIBquoskUMw==", "3cec666e-d757-49b0-ba57-e66987368878" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "19c34c01-41cf-45d6-a6fc-bafcb88ccfde", "AQAAAAEAACcQAAAAEKjM//26CN8axGLFGo2emc8dfCx9efMqCN4othkg0gBhCviuTuMApjV0nM+nFMpc0g==", "12dc50ae-bbe3-4c8f-9263-81edec9dae6e" });
        }
    }
}
