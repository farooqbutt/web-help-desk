using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebHelpDeskApp.Migrations
{
    public partial class Seventh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentReporter = table.Column<string>(nullable: true),
                    CommentText = table.Column<string>(nullable: true),
                    CommentDateTime = table.Column<DateTime>(nullable: true),
                    CommentAssignment = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Assignments_CommentAssignment",
                        column: x => x.CommentAssignment,
                        principalTable: "Assignments",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentAssignment",
                table: "Comments",
                column: "CommentAssignment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");
        }
    }
}
