using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.API.Migrations
{
    public partial class AddedSlugs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Technologies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Platforms",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Languages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Technologies");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Platforms");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Languages");
        }
    }
}
