using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebClient.Migrations
{
    public partial class db0002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PASSWORD",
                table: "USER",
                newName: "HASH");

            migrationBuilder.AddColumn<string>(
                name: "DEPT_CODE",
                table: "ORGANIZATION",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "END_DATETIME",
                table: "ORGANIZATION",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "START_DATETIME",
                table: "ORGANIZATION",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DEPT_CODE",
                table: "ORGANIZATION");

            migrationBuilder.DropColumn(
                name: "END_DATETIME",
                table: "ORGANIZATION");

            migrationBuilder.DropColumn(
                name: "START_DATETIME",
                table: "ORGANIZATION");

            migrationBuilder.RenameColumn(
                name: "HASH",
                table: "USER",
                newName: "PASSWORD");
        }
    }
}
