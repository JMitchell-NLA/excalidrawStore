using Microsoft.EntityFrameworkCore.Migrations;

namespace excalidrawCloud.Migrations
{
    public partial class ElementStateName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "content",
                table: "Excalidraws");

            migrationBuilder.AddColumn<string>(
                name: "elements",
                table: "Excalidraws",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Excalidraws",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "state",
                table: "Excalidraws",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "elements",
                table: "Excalidraws");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Excalidraws");

            migrationBuilder.DropColumn(
                name: "state",
                table: "Excalidraws");

            migrationBuilder.AddColumn<string>(
                name: "content",
                table: "Excalidraws",
                type: "text",
                nullable: true);
        }
    }
}
