using Microsoft.EntityFrameworkCore.Migrations;

namespace VaccineVerse.Migrations
{
    public partial class ageAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "age",
                table: "ApplicationUser",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "age",
                table: "ApplicationUser");
        }
    }
}
