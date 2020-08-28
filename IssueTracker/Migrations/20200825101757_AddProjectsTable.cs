using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IssueTracker.Migrations
{
    public partial class AddProjectsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Projectid",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: false),
                    createdDate = table.Column<DateTime>(nullable: false),
                    updatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Projectid",
                table: "AspNetUsers",
                column: "Projectid");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Projects_Projectid",
                table: "AspNetUsers",
                column: "Projectid",
                principalTable: "Projects",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Projects_Projectid",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Projectid",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Projectid",
                table: "AspNetUsers");
        }
    }
}
