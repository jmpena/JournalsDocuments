using Microsoft.EntityFrameworkCore.Migrations;

namespace Journals.Web.Migrations
{
    public partial class _003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalsDocuments_Researcher_ResearcherId",
                table: "JournalsDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Researcher",
                table: "Researcher");

            migrationBuilder.RenameTable(
                name: "Researcher",
                newName: "Researchers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Researchers",
                table: "Researchers",
                column: "ResearcherId");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalsDocuments_Researchers_ResearcherId",
                table: "JournalsDocuments",
                column: "ResearcherId",
                principalTable: "Researchers",
                principalColumn: "ResearcherId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalsDocuments_Researchers_ResearcherId",
                table: "JournalsDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Researchers",
                table: "Researchers");

            migrationBuilder.RenameTable(
                name: "Researchers",
                newName: "Researcher");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Researcher",
                table: "Researcher",
                column: "ResearcherId");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalsDocuments_Researcher_ResearcherId",
                table: "JournalsDocuments",
                column: "ResearcherId",
                principalTable: "Researcher",
                principalColumn: "ResearcherId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
