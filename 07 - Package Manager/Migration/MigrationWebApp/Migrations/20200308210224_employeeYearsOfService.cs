using Microsoft.EntityFrameworkCore.Migrations;

namespace MigrationWebApp.Migrations
{
    public partial class employeeYearsOfService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "YearsOfServices",
                table: "Employee",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YearsOfServices",
                table: "Employee");
        }
    }
}
