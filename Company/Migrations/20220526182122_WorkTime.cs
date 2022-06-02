using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company.Migrations
{
    public partial class WorkTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Deadline",
                table: "Projects",
                type: "DATETIME",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfAdoption",
                table: "Projects",
                type: "DATETIME",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME");

            migrationBuilder.AlterColumn<decimal>(
                name: "Budjet",
                table: "Projects",
                type: "DECIMAL",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL");

            migrationBuilder.CreateTable(
                name: "WorkTime",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numMonth = table.Column<int>(type: "int", nullable: true),
                    hours = table.Column<int>(type: "int", nullable: true),
                    lastRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    money = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkTime_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkTime_EmployeeId",
                table: "WorkTime",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkTime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Deadline",
                table: "Projects",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfAdoption",
                table: "Projects",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Budjet",
                table: "Projects",
                type: "DECIMAL",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL",
                oldNullable: true);
        }
    }
}
