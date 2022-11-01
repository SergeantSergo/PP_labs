using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PPlabs.Migrations
{
    public partial class InitialDatasklad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Plans",
                keyColumn: "PlanId",
                keyValue: new Guid("407f07d3-7d13-4c04-9c69-50aac805def0"));

            migrationBuilder.InsertData(
                table: "Plans",
                columns: new[] { "PlanId", "Date", "Kolvo", "Product", "Sklad1", "Sklad2" },
                values: new object[] { new Guid("596ed4b0-e6ec-4165-9159-29c9e134a277"), 1662757200L, 15, new Guid("6ad5696d-aaf8-4be3-95ff-4590d7b55133"), new Guid("1278a0ea-941f-4b7a-b3e8-d2e9ab900407"), new Guid("407f07d3-7d13-4c04-9c69-50aac805def2") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Plans",
                keyColumn: "PlanId",
                keyValue: new Guid("596ed4b0-e6ec-4165-9159-29c9e134a277"));

            migrationBuilder.InsertData(
                table: "Plans",
                columns: new[] { "PlanId", "Date", "Kolvo", "Product", "Sklad1", "Sklad2" },
                values: new object[] { new Guid("407f07d3-7d13-4c04-9c69-50aac805def0"), 1662757200L, 15, new Guid("407f07d3-7d13-4c04-9c69-50aac805def3"), new Guid("407f07d3-7d13-4c04-9c69-50aac805def1"), new Guid("407f07d3-7d13-4c04-9c69-50aac805def2") });
        }
    }
}
