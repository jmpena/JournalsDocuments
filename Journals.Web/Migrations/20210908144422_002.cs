using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Journals.Web.Migrations
{
    public partial class _002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "JournalsDocuments",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<int>(
                name: "ResearcherId",
                table: "JournalsDocuments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Researcher",
                columns: table => new
                {
                    ResearcherId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Researcher", x => x.ResearcherId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JournalsDocuments_ResearcherId",
                table: "JournalsDocuments",
                column: "ResearcherId");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalsDocuments_Researcher_ResearcherId",
                table: "JournalsDocuments",
                column: "ResearcherId",
                principalTable: "Researcher",
                principalColumn: "ResearcherId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalsDocuments_Researcher_ResearcherId",
                table: "JournalsDocuments");

            migrationBuilder.DropTable(
                name: "Researcher");

            migrationBuilder.DropIndex(
                name: "IX_JournalsDocuments_ResearcherId",
                table: "JournalsDocuments");

            migrationBuilder.DropColumn(
                name: "ResearcherId",
                table: "JournalsDocuments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "JournalsDocuments",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");
        }
    }
}
