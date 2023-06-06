using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BEComicWeb.Migrations
{
    public partial class update_story : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alias",
                table: "CategoriesDb");

            migrationBuilder.DropColumn(
                name: "Keyword",
                table: "CategoriesDb");

            migrationBuilder.DropColumn(
                name: "Alias",
                table: "AuthorsDb");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "StoriesDb",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "StoriesDb",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Views",
                table: "StoriesDb");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "StoriesDb",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Alias",
                table: "CategoriesDb",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Keyword",
                table: "CategoriesDb",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Alias",
                table: "AuthorsDb",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
