using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PPlabs.Migrations
{
    public partial class InitialData33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("4c09dd5d-15d6-4c3c-9cbf-c810b496aa0e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("fa533662-e939-4f53-aa8b-5db416fcf3c1"));

            migrationBuilder.DeleteData(
                table: "Sklads",
                keyColumn: "SkaldId",
                keyValue: new Guid("31ba897c-aec8-4a9b-a95d-11af407b821c"));

            migrationBuilder.DeleteData(
                table: "Sklads",
                keyColumn: "SkaldId",
                keyValue: new Guid("3ae0c0fd-5f60-4ce6-b33a-ba58ab5a63eb"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "IDSklad", "Kolvo", "NameProduct" },
                values: new object[,]
                {
                    { new Guid("231442f9-3ac9-4431-914c-6954adef1779"), new Guid("596ed4b0-e6ec-4165-9159-29c9e134a277"), 120, "Burger" },
                    { new Guid("6ad5696d-aaf8-4be3-95ff-4590d7b55133"), new Guid("1278a0ea-941f-4b7a-b3e8-d2e9ab900407"), 20, "fish" }
                });

            migrationBuilder.InsertData(
                table: "Sklads",
                columns: new[] { "SkaldId", "SkladName" },
                values: new object[,]
                {
                    { new Guid("1278a0ea-941f-4b7a-b3e8-d2e9ab900407"), "Octavia" },
                    { new Guid("596ed4b0-e6ec-4165-9159-29c9e134a277"), "UDyadiVani" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("231442f9-3ac9-4431-914c-6954adef1779"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("6ad5696d-aaf8-4be3-95ff-4590d7b55133"));

            migrationBuilder.DeleteData(
                table: "Sklads",
                keyColumn: "SkaldId",
                keyValue: new Guid("1278a0ea-941f-4b7a-b3e8-d2e9ab900407"));

            migrationBuilder.DeleteData(
                table: "Sklads",
                keyColumn: "SkaldId",
                keyValue: new Guid("596ed4b0-e6ec-4165-9159-29c9e134a277"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "IDSklad", "Kolvo", "NameProduct" },
                values: new object[,]
                {
                    { new Guid("4c09dd5d-15d6-4c3c-9cbf-c810b496aa0e"), new Guid("846699e0-c0b2-4654-a9e8-b4a7ee8f21ca"), 20, "fish" },
                    { new Guid("fa533662-e939-4f53-aa8b-5db416fcf3c1"), new Guid("f1b644cf-b485-4fee-b6e7-02b3766ca813"), 120, "Burger" }
                });

            migrationBuilder.InsertData(
                table: "Sklads",
                columns: new[] { "SkaldId", "SkladName" },
                values: new object[,]
                {
                    { new Guid("31ba897c-aec8-4a9b-a95d-11af407b821c"), "Octavia" },
                    { new Guid("3ae0c0fd-5f60-4ce6-b33a-ba58ab5a63eb"), "UDyadiVani" }
                });
        }
    }
}
