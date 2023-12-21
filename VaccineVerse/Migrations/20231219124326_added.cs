using Microsoft.EntityFrameworkCore.Migrations;

namespace VaccineVerse.Migrations
{
    public partial class added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "identityUserId",
                table: "ApplicationUser",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_identityUserId",
                table: "ApplicationUser",
                column: "identityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_AspNetUsers_identityUserId",
                table: "ApplicationUser",
                column: "identityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUser_AspNetUsers_identityUserId",
                table: "ApplicationUser");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUser_identityUserId",
                table: "ApplicationUser");

            migrationBuilder.DropColumn(
                name: "identityUserId",
                table: "ApplicationUser");
        }
    }
}
