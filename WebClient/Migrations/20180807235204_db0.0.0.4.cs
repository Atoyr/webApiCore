using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebClient.Migrations
{
    public partial class db0004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MAIL",
                table: "USER",
                newName: "EMAIL");

            migrationBuilder.CreateTable(
                name: "AUTHORIZATION",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CREATE_USER = table.Column<string>(nullable: true),
                    CREATE_DATETIME = table.Column<DateTime>(nullable: false),
                    UPDATE_USER = table.Column<string>(nullable: true),
                    UPDATE_DATETIME = table.Column<DateTime>(nullable: false),
                    COMPANY_ID = table.Column<Guid>(nullable: false),
                    USER_ID = table.Column<Guid>(nullable: false),
                    VALUE = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUTHORIZATION", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AUTHORIZATION");

            migrationBuilder.RenameColumn(
                name: "EMAIL",
                table: "USER",
                newName: "MAIL");
        }
    }
}
