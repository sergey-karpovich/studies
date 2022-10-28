using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeAPI.Migrations
{
    public partial class workTimeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "Employees",
                newName: "EmployeeId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Hours",
                table: "WorkTimes",
                type: "DECIMAL",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "WorkTimes",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumYear",
                table: "WorkTimes",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "WorkTimes");

            migrationBuilder.DropColumn(
                name: "NumYear",
                table: "WorkTimes");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Employees",
                newName: "EmployeeID");

            migrationBuilder.AlterColumn<int>(
                name: "Hours",
                table: "WorkTimes",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL",
                oldNullable: true);
        }
    }
}
