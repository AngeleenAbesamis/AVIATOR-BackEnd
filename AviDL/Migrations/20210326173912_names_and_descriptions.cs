using Microsoft.EntityFrameworkCore.Migrations;

namespace AviDL.Migrations
{
    public partial class names_and_descriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ParsedID",
                table: "Scenes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SceneDescription",
                table: "Scenes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SceneName",
                table: "Scenes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PilotDescription",
                table: "Pilots",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PilotName",
                table: "Pilots",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileDescription",
                table: "Files",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Files",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParsedID",
                table: "Files",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParsedID",
                table: "Scenes");

            migrationBuilder.DropColumn(
                name: "SceneDescription",
                table: "Scenes");

            migrationBuilder.DropColumn(
                name: "SceneName",
                table: "Scenes");

            migrationBuilder.DropColumn(
                name: "PilotDescription",
                table: "Pilots");

            migrationBuilder.DropColumn(
                name: "PilotName",
                table: "Pilots");

            migrationBuilder.DropColumn(
                name: "FileDescription",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "ParsedID",
                table: "Files");
        }
    }
}
