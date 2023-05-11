using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BEComicWeb.Migrations
{
    public partial class category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoryAuthorDb_AuthorsDb_AuthorId",
                table: "StoryAuthorDb");

            migrationBuilder.DropForeignKey(
                name: "FK_StoryTranslatorDb_Translators_TranslatorId",
                table: "StoryTranslatorDb");

            migrationBuilder.DropTable(
                name: "Translators");

            migrationBuilder.AddColumn<int>(
                name: "Coins",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "National",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ImageDb_ImageId",
                table: "AspNetUsers",
                column: "ImageId",
                principalTable: "ImageDb",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StoryAuthorDb_AspNetUsers_AuthorId",
                table: "StoryAuthorDb",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StoryTranslatorDb_AspNetUsers_TranslatorId",
                table: "StoryTranslatorDb",
                column: "TranslatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ImageDb_ImageId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_StoryAuthorDb_AspNetUsers_AuthorId",
                table: "StoryAuthorDb");

            migrationBuilder.DropForeignKey(
                name: "FK_StoryTranslatorDb_AspNetUsers_TranslatorId",
                table: "StoryTranslatorDb");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Coins",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "National",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Translators",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    National = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translators", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_StoryAuthorDb_AuthorsDb_AuthorId",
                table: "StoryAuthorDb",
                column: "AuthorId",
                principalTable: "AuthorsDb",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StoryTranslatorDb_Translators_TranslatorId",
                table: "StoryTranslatorDb",
                column: "TranslatorId",
                principalTable: "Translators",
                principalColumn: "Id");
        }
    }
}
