using Microsoft.EntityFrameworkCore.Migrations;

namespace IssueTracker.Migrations
{
    public partial class RemoveUserIdFromProjectsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userId",
                table: "Projects");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
