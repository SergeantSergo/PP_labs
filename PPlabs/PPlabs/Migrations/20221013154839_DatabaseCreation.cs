using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PPlabs.Migrations
{
    public partial class DatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sklad1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sklad2 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Product = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Kolvo = table.Column<int>(type: "int", maxLength: 60, nullable: false),
                    Date = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.PlanId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameProduct = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Kolvo = table.Column<int>(type: "int", nullable: false),
                    IDSklad = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Sklads",
                columns: table => new
                {
                    SkaldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkladName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sklads", x => x.SkaldId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "Address", "Country", "Name" },
                values: new object[,]
                {
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "312 Forest Avenue, BF 923", "USA", "Admin_Solutions Ltd" },
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "583 Wall Dr. Gwynn Oak, MD 21207", "USA", "IT_Solutions Ltd" }
                });

            migrationBuilder.InsertData(
                table: "Plans",
                columns: new[] { "PlanId", "Date", "Kolvo", "Product", "Sklad1", "Sklad2" },
                values: new object[] { new Guid("407f07d3-7d13-4c04-9c69-50aac805def0"), 1662757200L, 15, new Guid("407f07d3-7d13-4c04-9c69-50aac805def3"), new Guid("407f07d3-7d13-4c04-9c69-50aac805def1"), new Guid("407f07d3-7d13-4c04-9c69-50aac805def2") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "IDSklad", "Kolvo", "NameProduct" },
                values: new object[,]
                {
                    { new Guid("15b7d544-1898-4b1a-902f-ff7928fce19e"), new Guid("ec0d2aa2-6b80-4d44-91b7-53a653a612d5"), 120, "Burger" },
                    { new Guid("992b55a4-46c9-4f28-b60b-549e13386fda"), new Guid("9d4546a3-7fb6-4aef-a80d-83f9eec5a4ad"), 20, "fish" }
                });

            migrationBuilder.InsertData(
                table: "Sklads",
                columns: new[] { "SkaldId", "SkladName" },
                values: new object[,]
                {
                    { new Guid("b6f1aef0-ebf1-4ed3-9b9b-6951d4aec92e"), "UDyadiVani" },
                    { new Guid("e8b8ab78-0822-403c-a39f-3e34de692b3f"), "Octavia" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "Name", "Position" },
                values: new object[] { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), 35, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Kane Miller", "Administrator" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "Name", "Position" },
                values: new object[] { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), 26, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Sam Raiden", "Software developer" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "Name", "Position" },
                values: new object[] { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), 30, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Jana McLeaf", "Software developer" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sklads");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
