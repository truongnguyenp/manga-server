using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BEComicWeb.Migrations
{
    public partial class delete_follows : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Follows",
                table: "Translators");

            migrationBuilder.DropColumn(
                name: "Follows",
                table: "StoriesDb");

            migrationBuilder.DropColumn(
                name: "Follows",
                table: "AuthorsDb");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Follows",
                table: "Translators",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Follows",
                table: "StoriesDb",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Follows",
                table: "AuthorsDb",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
