using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace excalidrawCloud.Migrations
{
    public partial class DatesAndHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Excalidraws",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "lastSaved",
                table: "Excalidraws",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "owner",
                table: "Excalidraws",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "endDate",
                table: "Excalidraws",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "startDate",
                table: "Excalidraws",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Excalidraws");

            migrationBuilder.DropColumn(
                name: "lastSaved",
                table: "Excalidraws");

            migrationBuilder.DropColumn(
                name: "owner",
                table: "Excalidraws");

            migrationBuilder.DropColumn(
                name: "endDate",
                table: "Excalidraws");

            migrationBuilder.DropColumn(
                name: "startDate",
                table: "Excalidraws");
        }
    }
}
