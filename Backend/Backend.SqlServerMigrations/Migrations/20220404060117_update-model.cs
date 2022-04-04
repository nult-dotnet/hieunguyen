using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.SqlServerMigrations.Migrations
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                value: new DateTime(2022, 4, 4, 13, 1, 17, 222, DateTimeKind.Local).AddTicks(5430));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 4, 4, 13, 1, 17, 223, DateTimeKind.Local).AddTicks(3778));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 4, 4, 13, 1, 17, 223, DateTimeKind.Local).AddTicks(3868));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 4, 4, 13, 1, 17, 223, DateTimeKind.Local).AddTicks(3872));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 4, 4, 13, 1, 17, 223, DateTimeKind.Local).AddTicks(3874));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "c4594865-7367-4e70-bafa-eaae3cef51e1");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "94ee7010-483e-4e3b-8704-633ff0e4e69f");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "7be646d5-2f16-4dfc-846d-4451060492e8");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7f2fb4a-902c-41f9-b6d3-aa2af2ea2a1d", "AQAAAAEAACcQAAAAENCukbM9EY59+Yybc0L2n8SFwyZkOfUTq4WXVcwvFH00Jo0FoLZ0ctdy7wzHz5Wi9w==", "54cf6ea0-77c0-4b66-985e-25d03d3527b2" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "699c9811-a4ce-4414-8fde-3831792a54d6", "AQAAAAEAACcQAAAAELld3Pqo4JW+bI81sbIju3lrm7WR/FI9sYXXoTwBDDdsqbWYwWWtGEpFr+H3zTfcww==", "54b6a3af-2cd2-426f-bbc7-1f877d7d3d04" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ecf7e61d-14ed-444a-a3e0-b844341d2aef", "AQAAAAEAACcQAAAAEFAUC2oftCEqhqacsiuwJjIPQDaS1PlOtuSBIxuHamwnT7JvgIBn/oy3HpIs/+7Nzg==", "1179811e-379a-43da-9a9d-fe59bf090106" });

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
                value: new DateTime(2022, 4, 4, 6, 40, 5, 631, DateTimeKind.Local).AddTicks(3618));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 4, 4, 6, 40, 5, 632, DateTimeKind.Local).AddTicks(719));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 4, 4, 6, 40, 5, 632, DateTimeKind.Local).AddTicks(785));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 4, 4, 6, 40, 5, 632, DateTimeKind.Local).AddTicks(787));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 4, 4, 6, 40, 5, 632, DateTimeKind.Local).AddTicks(789));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "60b54e15-560b-4e6d-a830-a379fafd2802");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "4e417509-6cb0-4f36-9f96-4a16bd20d9e6");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "4a6a8256-a7d1-4f68-b9ad-2904d3faa07a");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81c82aa4-ff54-422f-8159-fbabfde2de0e", "AQAAAAEAACcQAAAAEIdX9t9XyZ1fPTqjv0SbA5jf/cyI3YUaOFd2+pbztzR9b3P+XbLWpJPHCRRoyuwbDQ==", "0604e233-d49a-4dc0-b917-49e596a57f70" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "775d522d-4bf2-4837-8305-b4c2c7f2c38d", "AQAAAAEAACcQAAAAECpeqT4CIJqK/EFO0NHeFfZ3gezefFhkjR7T8EVYS2iwKNtyhyLWyH337Xd1m1k6mw==", "b6cba3bc-59fa-4ac4-afe5-7ade5c543935" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f58ab1fb-e2ac-4aff-a6f0-5ea3229fd897", "AQAAAAEAACcQAAAAELgCcpIU3vgKTPFXOYbcgijLYQXR/PS1R5PYLimVKMbvTlQpMoK4JC+MqkNs2pp3IA==", "c24d9ecd-1ae0-4f61-90a9-5d785bbc8d10" });
        }
    }
}
