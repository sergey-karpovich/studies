using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeAPI.Migrations
{
    public partial class workTimeSomeChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkTimes_Employees_EmployeeId",
                table: "WorkTimes");

            migrationBuilder.DropColumn(
                name: "Money",
                table: "WorkTimes");

            migrationBuilder.AlterColumn<decimal>(
                name: "LastRate",
                table: "WorkTimes",
                type: "DECIMAL",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "EmployeeId",
                table: "WorkTimes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProjectId",
                table: "WorkTimes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTimes_Employees_EmployeeId",
                table: "WorkTimes",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkTimes_Employees_EmployeeId",
                table: "WorkTimes");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "WorkTimes");

            migrationBuilder.AlterColumn<decimal>(
                name: "LastRate",
                table: "WorkTimes",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "EmployeeId",
                table: "WorkTimes",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<decimal>(
                name: "Money",
                table: "WorkTimes",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTimes_Employees_EmployeeId",
                table: "WorkTimes",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeID");
        }
    }
}
