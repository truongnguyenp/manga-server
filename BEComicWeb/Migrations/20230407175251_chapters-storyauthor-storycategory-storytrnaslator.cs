using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BEComicWeb.Migrations
{
    public partial class chaptersstoryauthorstorycategorystorytrnaslator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Stories",
                type: "varchar(60)",
                unicode: false,
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Stories",
                type: "varchar(1000)",
                unicode: false,
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    Description = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Alias = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    Keyword = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chapters",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StoryId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChapterNumner = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    Cost = table.Column<int>(type: "int", unicode: false, nullable: true),
                    Image = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Views = table.Column<int>(type: "int", unicode: false, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StoryAuthor",
                columns: table => new
                {
                    AuthorId = table.Column<string>(type: "varchar(900)", unicode: false, nullable: false),
                    StoryId = table.Column<string>(type: "varchar(900)", unicode: false, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryAuthor", x => new { x.StoryId, x.AuthorId });
                });

            migrationBuilder.CreateTable(
                name: "StoryCategories",
                columns: table => new
                {
                    StoryId = table.Column<string>(type: "varchar(900)", unicode: false, nullable: false),
                    CategoryId = table.Column<string>(type: "varchar(900)", unicode: false, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryCategories", x => new { x.StoryId, x.CategoryId });
                });

            migrationBuilder.CreateTable(
                name: "StoryTranslator",
                columns: table => new
                {
                    StoryId = table.Column<string>(type: "varchar(900)", unicode: false, nullable: false),
                    TranslatorId = table.Column<string>(type: "varchar(900)", unicode: false, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryTranslator", x => new { x.StoryId, x.TranslatorId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Chapters");

            migrationBuilder.DropTable(
                name: "StoryAuthor");

            migrationBuilder.DropTable(
                name: "StoryCategories");

            migrationBuilder.DropTable(
                name: "StoryTranslator");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Stories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(60)",
                oldUnicode: false,
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Stories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldUnicode: false,
                oldMaxLength: 1000,
                oldNullable: true);
        }
    }
}
