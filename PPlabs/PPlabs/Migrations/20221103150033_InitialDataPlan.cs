using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PPlabs.Migrations
{
    public partial class InitialDataPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Plans",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Plans",
                keyColumn: "PlanId",
                keyValue: new Guid("407f07d3-7d13-4c04-9c69-50aac805def2"),
                column: "Name",
                value: "Первый план");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Plans");
        }
    }
}
