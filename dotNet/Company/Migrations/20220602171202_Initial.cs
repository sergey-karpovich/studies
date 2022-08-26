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
                    EmployeeID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
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
                    ReportsTo = table.Column<long>(type: "int", nullable: true),
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
                    ProjectID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
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
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    numMonth = table.Column<int>(type: "INTEGER", nullable: true),
                    hours = table.Column<int>(type: "INTEGER", nullable: true),
                    lastRate = table.Column<decimal>(type: "TEXT", nullable: true),
                    money = table.Column<decimal>(type: "TEXT", nullable: true),
                    EmployeeId = table.Column<long>(type: "INTEGER", nullable: true)
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
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProjectId = table.Column<long>(type: "INTEGER", nullable: false),
                    EmployeeId = table.Column<long>(type: "INTEGER", nullable: false)
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
