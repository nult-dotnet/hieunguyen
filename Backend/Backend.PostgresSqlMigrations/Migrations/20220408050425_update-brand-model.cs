using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.PostgresSqlMigrations.Migrations
{
    public partial class updatebrandmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brand_User_UserId",
                table: "Brand");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Brand",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brand",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 4, 8, 12, 4, 25, 230, DateTimeKind.Local).AddTicks(5312));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 4, 8, 12, 4, 25, 231, DateTimeKind.Local).AddTicks(4290));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 4, 8, 12, 4, 25, 231, DateTimeKind.Local).AddTicks(4388));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 4, 8, 12, 4, 25, 231, DateTimeKind.Local).AddTicks(4392));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 4, 8, 12, 4, 25, 231, DateTimeKind.Local).AddTicks(4426));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "2489eba4-de4f-41f7-8bdf-325c4284d0c5");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "47134eca-ad2b-4159-8ec7-d5eceee39aef");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "0c818811-a900-4e68-8ca9-0fb1d3a53da5");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f9eeed7-e956-485c-b9e9-da303bb66491", "AQAAAAEAACcQAAAAEKzlzdavqt373T7aTRXJd2/soNOtGQMrrna3i1F5GTtMg9spgXtGM9lhSQv0ZHekcw==", "ee51ba9c-2bd7-4375-9e4e-19339fc91e31" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b8629bf-12a3-40e5-ac35-24a9cf9d200d", "AQAAAAEAACcQAAAAEDGaZZj/9+TQZhNOiHyra6rLapoOrBMTo4DUqbvdtu74NwWmamWF4nbei59FMgGTuA==", "4405b88e-f1f3-4ab5-a321-e5b0779d2055" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eae458e2-2bad-49cb-b04f-88966ab4b10b", "AQAAAAEAACcQAAAAENDUicEeCTYKsT4DE1kXzNKTSehFmfcelOUwTwYX1cXtmhbVD3Q4uRDRJAvEzVzNqg==", "6c9506c5-2a9f-43e7-b472-107c24f41f66" });

            migrationBuilder.CreateIndex(
                name: "IX_Brand_Name",
                table: "Brand",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Brand_User_UserId",
                table: "Brand",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brand_User_UserId",
                table: "Brand");

            migrationBuilder.DropIndex(
                name: "IX_Brand_Name",
                table: "Brand");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Brand",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brand",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Brand_User_UserId",
                table: "Brand",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
