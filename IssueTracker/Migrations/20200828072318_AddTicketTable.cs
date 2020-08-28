using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IssueTracker.Migrations
{
    public partial class AddTicketTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Projects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    projectId = table.Column<int>(nullable: false),
                    ownerUserId = table.Column<int>(nullable: false),
                    assignedUserId = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: false),
                    createdDate = table.Column<DateTime>(nullable: false),
                    updatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tickets_Projects_projectId",
                        column: x => x.projectId,
                        principalTable: "Projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_projectId",
                table: "Tickets",
                column: "projectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Projects");
        }
    }
}
