using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeAPI.Migrations
{
    public partial class projectEmployeeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProjectID",
                table: "Projects",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ProjectID",
                table: "Projects",
                newName: "IX_Projects_ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Projects",
                newName: "ProjectID");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ProjectId",
                table: "Projects",
                newName: "IX_Projects_ProjectID");
        }
    }
}
