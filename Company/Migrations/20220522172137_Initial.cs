using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar (20)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar (10)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar (30)", nullable: true),
                    TitleOfCourtesy = table.Column<string>(type: "nvarchar (25)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Address = table.Column<string>(type: "nvarchar (60)", nullable: true),
                    City = table.Column<string>(type: "nvarchar (15)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar (15)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar (10)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar (15)", nullable: true),
                    HomePhone = table.Column<string>(type: "nvarchar (24)", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar (4)", nullable: true),
                    Photo = table.Column<byte[]>(type: "image", nullable: true),
                    Notes = table.Column<string>(type: "ntext", nullable: true),
                    ReportsTo = table.Column<int>(type: "int", nullable: true),
                    PhotoPath = table.Column<string>(type: "nvarchar (255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "VARCHAR (20)", nullable: true),
                    Description = table.Column<string>(type: "VARCHAR (200)", nullable: true),
                    DateOfAdoption = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Deadline = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Budjet = table.Column<decimal>(type: "DECIMAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectID);
                });

            migrationBuilder.CreateIndex(
                name: "LastName",
                table: "Employees",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "PostalCodeEmployees",
                table: "Employees",
                column: "PostalCode");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectID",
                table: "Projects",
                column: "ProjectID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
