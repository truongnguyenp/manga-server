using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BEComicWeb.Migrations
{
    public partial class init_like_and_follow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChapterLikesDb",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChapterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChapterLikesDb", x => new { x.UserName, x.ChapterId });
                });

            migrationBuilder.CreateTable(
                name: "StoryFollowsDb",
                columns: table => new
                {
                    StoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryFollowsDb", x => new { x.UserName, x.StoryId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChapterLikesDb");

            migrationBuilder.DropTable(
                name: "StoryFollowsDb");
        }
    }
}
