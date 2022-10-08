using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeAPI.Migrations
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

            migrationBuilder.CreateTable(
                name: "WorkTimes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumMonth = table.Column<int>(type: "int", nullable: true),
                    Hours = table.Column<int>(type: "int", nullable: true),
                    LastRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Money = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkTimes_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateTable(
                name: "ProjectEmployeeJunction",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEmployeeJunction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectEmployeeJunction_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectEmployeeJunction_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "Address", "BirthDate", "City", "Country", "Extension", "FirstName", "HireDate", "HomePhone", "LastName", "Notes", "Photo", "PhotoPath", "PostalCode", "Region", "ReportsTo", "Title", "TitleOfCourtesy" },
                values: new object[] { 1L, null, null, null, null, null, null, null, null, "Tom", null, null, null, null, null, null, "test data title", null });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "Address", "BirthDate", "City", "Country", "Extension", "FirstName", "HireDate", "HomePhone", "LastName", "Notes", "Photo", "PhotoPath", "PostalCode", "Region", "ReportsTo", "Title", "TitleOfCourtesy" },
                values: new object[] { 2L, null, null, null, null, null, null, null, null, "Alice", null, null, null, null, null, null, "test data title", null });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "Address", "BirthDate", "City", "Country", "Extension", "FirstName", "HireDate", "HomePhone", "LastName", "Notes", "Photo", "PhotoPath", "PostalCode", "Region", "ReportsTo", "Title", "TitleOfCourtesy" },
                values: new object[] { 3L, null, null, null, null, null, null, null, null, "Sam", null, null, null, null, null, null, "test data title", null });

            migrationBuilder.CreateIndex(
                name: "LastName",
                table: "Employees",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "PostalCodeEmployees",
                table: "Employees",
                column: "PostalCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployeeJunction_EmployeeId",
                table: "ProjectEmployeeJunction",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployeeJunction_ProjectId",
                table: "ProjectEmployeeJunction",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectID",
                table: "Projects",
                column: "ProjectID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkTimes_EmployeeId",
                table: "WorkTimes",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectEmployeeJunction");

            migrationBuilder.DropTable(
                name: "WorkTimes");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
