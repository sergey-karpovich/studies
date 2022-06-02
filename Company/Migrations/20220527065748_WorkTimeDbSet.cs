using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company.Migrations
{
    public partial class WorkTimeDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkTime_Employees_EmployeeId",
                table: "WorkTime");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkTime",
                table: "WorkTime");

            migrationBuilder.RenameTable(
                name: "WorkTime",
                newName: "WorkTimes");

            migrationBuilder.RenameIndex(
                name: "IX_WorkTime_EmployeeId",
                table: "WorkTimes",
                newName: "IX_WorkTimes_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkTimes",
                table: "WorkTimes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTimes_Employees_EmployeeId",
                table: "WorkTimes",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkTimes_Employees_EmployeeId",
                table: "WorkTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkTimes",
                table: "WorkTimes");

            migrationBuilder.RenameTable(
                name: "WorkTimes",
                newName: "WorkTime");

            migrationBuilder.RenameIndex(
                name: "IX_WorkTimes_EmployeeId",
                table: "WorkTime",
                newName: "IX_WorkTime_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkTime",
                table: "WorkTime",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTime_Employees_EmployeeId",
                table: "WorkTime",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeID");
        }
    }
}
