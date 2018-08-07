using Microsoft.EntityFrameworkCore.Migrations;

namespace WebClient.Migrations
{
    public partial class db0003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FIRST_NAME",
                table: "USER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LAST_NAME",
                table: "USER",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FIRST_NAME",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "LAST_NAME",
                table: "USER");
        }
    }
}
