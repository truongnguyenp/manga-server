using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BEComicWeb.Migrations
{
    public partial class objectStory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChaptersDb_StoriesDb_StoryId",
                table: "ChaptersDb");

            migrationBuilder.DropIndex(
                name: "IX_ChaptersDb_StoryId",
                table: "ChaptersDb");

            migrationBuilder.AlterColumn<string>(
                name: "StoryId",
                table: "ChaptersDb",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StoryId",
                table: "ChaptersDb",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChaptersDb_StoryId",
                table: "ChaptersDb",
                column: "StoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChaptersDb_StoriesDb_StoryId",
                table: "ChaptersDb",
                column: "StoryId",
                principalTable: "StoriesDb",
                principalColumn: "Id");
        }
    }
}
