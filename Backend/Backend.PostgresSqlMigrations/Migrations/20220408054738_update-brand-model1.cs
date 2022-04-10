using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.PostgresSqlMigrations.Migrations
{
    public partial class updatebrandmodel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Brand_Name",
                table: "Brand");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 4, 8, 12, 47, 37, 780, DateTimeKind.Local).AddTicks(8723));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 4, 8, 12, 47, 37, 781, DateTimeKind.Local).AddTicks(5866));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 4, 8, 12, 47, 37, 781, DateTimeKind.Local).AddTicks(5934));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 4, 8, 12, 47, 37, 781, DateTimeKind.Local).AddTicks(5937));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 4, 8, 12, 47, 37, 781, DateTimeKind.Local).AddTicks(5938));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "bc5f4ee9-5bd9-4c45-a0e5-388934fb652e");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "ba6a9d53-3e3e-4da7-966b-3684ef795168");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "156b889f-849f-4fd0-b900-5ec21ea088e3");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c47e5ac7-41f7-4848-892a-cd8885b18ce3", "AQAAAAEAACcQAAAAEBhhYWJGK+SlHarYKHu/p9Pj4XRFoFJ90m4uhxEptxOypweOIniKnKy2iGhVKU5qhQ==", "6205a867-eacd-4ddb-959c-d2a3250d631f" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c0fba7a3-b96c-4a2d-ac03-ff1f68f7cee4", "AQAAAAEAACcQAAAAEPIMWxJZvSesvJgWfXX400x5HHFA5JGVk9OfqL32iYV4FM4VpR2UGPho9m5nYZwCpQ==", "51fbd962-976f-4a22-968a-4d63ed390de3" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4fff5a1b-df67-4e24-9d9d-f2ae476a8cea", "AQAAAAEAACcQAAAAEL/0dtfJ+2IjywTyp2EuVbYIdKfZP7PsuinWjDFUV+i9ytSa/Nq0gxufzJFWpqgNuw==", "0b645712-030e-4673-89e9-6bbbf63a801b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
