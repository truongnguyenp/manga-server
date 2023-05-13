using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BEComicWeb.Migrations
{
    public partial class add_chapter_image : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChapterImagesDb",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImageId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    ChapterId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChapterImagesDb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChapterImagesDb_ChaptersDb_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "ChaptersDb",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChapterImagesDb_ImageDb_ImageId",
                        column: x => x.ImageId,
                        principalTable: "ImageDb",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChapterImagesDb_ChapterId",
                table: "ChapterImagesDb",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_ChapterImagesDb_ImageId",
                table: "ChapterImagesDb",
                column: "ImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChapterImagesDb");
        }
    }
}
