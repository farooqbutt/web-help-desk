using Microsoft.EntityFrameworkCore.Migrations;

namespace WebHelpDeskApp.Migrations
{
    public partial class Fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Assignments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Assignments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
