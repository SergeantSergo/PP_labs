using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PPlabs.Migrations
{
    public partial class InitialData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("6a3eb9e6-2854-4de3-ba98-1ccf47cd5ced"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("ebe02987-9620-4c57-8804-5d92507a3cbf"));

            migrationBuilder.DeleteData(
                table: "Sklads",
                keyColumn: "SkaldId",
                keyValue: new Guid("97f1f36a-67e0-4162-a9f3-fd6df37be3d1"));

            migrationBuilder.DeleteData(
                table: "Sklads",
                keyColumn: "SkaldId",
                keyValue: new Guid("f337efbf-a607-4957-9253-7e04b6b1b8df"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "IDSklad", "Kolvo", "NameProduct" },
                values: new object[,]
                {
                    { new Guid("bd679046-ed00-44e5-9ab0-bf98d0c71056"), new Guid("b0e0849d-d9bf-47f5-b467-7b2793bd293a"), 120, "Burger" },
                    { new Guid("e0fc04d4-98a7-420d-a3d7-5b05caa3dedb"), new Guid("064f2837-99e7-47f5-985a-81a5b40a5f5a"), 20, "fish" }
                });

            migrationBuilder.InsertData(
                table: "Sklads",
                columns: new[] { "SkaldId", "SkladName" },
                values: new object[,]
                {
                    { new Guid("0834ed03-257b-40f8-95fb-4ae41921dc52"), "UDyadiVani" },
                    { new Guid("1e24ab27-dc50-4487-8374-ac6db8dc841e"), "Octavia" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("bd679046-ed00-44e5-9ab0-bf98d0c71056"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("e0fc04d4-98a7-420d-a3d7-5b05caa3dedb"));

            migrationBuilder.DeleteData(
                table: "Sklads",
                keyColumn: "SkaldId",
                keyValue: new Guid("0834ed03-257b-40f8-95fb-4ae41921dc52"));

            migrationBuilder.DeleteData(
                table: "Sklads",
                keyColumn: "SkaldId",
                keyValue: new Guid("1e24ab27-dc50-4487-8374-ac6db8dc841e"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "IDSklad", "Kolvo", "NameProduct" },
                values: new object[,]
                {
                    { new Guid("6a3eb9e6-2854-4de3-ba98-1ccf47cd5ced"), new Guid("c5ace05c-da20-4dca-b670-e9f668955b17"), 120, "Burger" },
                    { new Guid("ebe02987-9620-4c57-8804-5d92507a3cbf"), new Guid("6fbe9236-2e40-4c3f-878c-052a2c31aaac"), 20, "fish" }
                });

            migrationBuilder.InsertData(
                table: "Sklads",
                columns: new[] { "SkaldId", "SkladName" },
                values: new object[,]
                {
                    { new Guid("97f1f36a-67e0-4162-a9f3-fd6df37be3d1"), "UDyadiVani" },
                    { new Guid("f337efbf-a607-4957-9253-7e04b6b1b8df"), "Octavia" }
                });
        }
    }
}
