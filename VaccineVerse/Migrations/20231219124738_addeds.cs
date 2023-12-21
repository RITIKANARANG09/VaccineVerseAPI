using Microsoft.EntityFrameworkCore.Migrations;

namespace VaccineVerse.Migrations
{
    public partial class addeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUser_Role_RoleId",
                table: "ApplicationUser");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUser_RoleId",
                table: "ApplicationUser");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "ApplicationUser");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "ApplicationUser",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "ApplicationUser");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "ApplicationUser",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_RoleId",
                table: "ApplicationUser",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_Role_RoleId",
                table: "ApplicationUser",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
