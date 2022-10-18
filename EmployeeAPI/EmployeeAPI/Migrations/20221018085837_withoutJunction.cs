using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeAPI.Migrations
{
    public partial class withoutJunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectEmployeeJunction");

            migrationBuilder.AlterColumn<string>(
                name: "Region",
                table: "Employees",
                type: "nvarchar (150)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar (15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Employees",
                type: "nvarchar (100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar (10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Employees",
                type: "nvarchar (100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar (20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Employees",
                type: "nvarchar (100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar (10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Extension",
                table: "Employees",
                type: "nvarchar (100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar (4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Employees",
                type: "nvarchar (150)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar (15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Employees",
                type: "nvarchar (150)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar (15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Employees",
                type: "nvarchar (150)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar (60)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "EmployeeProject",
                columns: table => new
                {
                    EmployeesEmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    ProjectsProjectID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProject", x => new { x.EmployeesEmployeeId, x.ProjectsProjectID });
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Employees_EmployeesEmployeeId",
                        column: x => x.EmployeesEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Projects_ProjectsProjectID",
                        column: x => x.ProjectsProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProject_ProjectsProjectID",
                table: "EmployeeProject",
                column: "ProjectsProjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeProject");

            migrationBuilder.AlterColumn<string>(
                name: "Region",
                table: "Employees",
                type: "nvarchar (15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar (150)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Employees",
                type: "nvarchar (10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar (100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Employees",
                type: "nvarchar (20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar (100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Employees",
                type: "nvarchar (10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar (100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Extension",
                table: "Employees",
                type: "nvarchar (4)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar (100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Employees",
                type: "nvarchar (15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar (150)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Employees",
                type: "nvarchar (15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar (150)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Employees",
                type: "nvarchar (60)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar (150)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ProjectEmployeeJunction",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false)
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
                name: "IX_ProjectEmployeeJunction_EmployeeId",
                table: "ProjectEmployeeJunction",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployeeJunction_ProjectId",
                table: "ProjectEmployeeJunction",
                column: "ProjectId");
        }
    }
}
