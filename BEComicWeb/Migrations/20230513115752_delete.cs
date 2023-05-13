using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BEComicWeb.Migrations
{
    public partial class delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ImageDb_ImageId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ChapterImagesDb_ImageDb_ImageId",
                table: "ChapterImagesDb");

            migrationBuilder.DropForeignKey(
                name: "FK_StoriesDb_ImageDb_ImageId",
                table: "StoriesDb");

            migrationBuilder.DropTable(
                name: "ImageDb");

            migrationBuilder.DropIndex(
                name: "IX_StoriesDb_ImageId",
                table: "StoriesDb");

            migrationBuilder.DropIndex(
                name: "IX_ChapterImagesDb_ImageId",
                table: "ChapterImagesDb");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "StoriesDb");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "ChapterImagesDb");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "StoriesDb",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "ChapterImagesDb",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserImage",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "StoriesDb");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "ChapterImagesDb");

            migrationBuilder.DropColumn(
                name: "UserImage",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "StoriesDb",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "ChapterImagesDb",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ImageDb",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Storage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageDb", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoriesDb_ImageId",
                table: "StoriesDb",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ChapterImagesDb_ImageId",
                table: "ChapterImagesDb",
                column: "ImageId");

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
                name: "FK_ChapterImagesDb_ImageDb_ImageId",
                table: "ChapterImagesDb",
                column: "ImageId",
                principalTable: "ImageDb",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StoriesDb_ImageDb_ImageId",
                table: "StoriesDb",
                column: "ImageId",
                principalTable: "ImageDb",
                principalColumn: "Id");
        }
    }
}
