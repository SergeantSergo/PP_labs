using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PPlabs.Migrations
{
    public partial class InitialData4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
