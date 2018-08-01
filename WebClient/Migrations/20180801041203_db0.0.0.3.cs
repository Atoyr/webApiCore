using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebClient.Migrations
{
    public partial class db0003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "SALT",
                table: "USER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ADDRESS",
                table: "COMPANY",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "APPROVAL_ROUTE",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CREATE_USER = table.Column<string>(nullable: true),
                    CREATE_DATETIME = table.Column<DateTime>(nullable: false),
                    UPDATE_USER = table.Column<string>(nullable: true),
                    UPDATE_DATETIME = table.Column<DateTime>(nullable: false),
                    NAME = table.Column<string>(nullable: true),
                    COMP_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APPROVAL_ROUTE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ORGANIZATION",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CREATE_USER = table.Column<string>(nullable: true),
                    CREATE_DATETIME = table.Column<DateTime>(nullable: false),
                    UPDATE_USER = table.Column<string>(nullable: true),
                    UPDATE_DATETIME = table.Column<DateTime>(nullable: false),
                    NAME = table.Column<string>(nullable: true),
                    PARENT_ID = table.Column<Guid>(nullable: false),
                    ORDER = table.Column<int>(nullable: false),
                    COMP_ID = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: true),
                    OrganizationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORGANIZATION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ORGANIZATION_COMPANY_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "COMPANY",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ORGANIZATION_ORGANIZATION_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "ORGANIZATION",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ORGANIZATION_CompanyId",
                table: "ORGANIZATION",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ORGANIZATION_OrganizationId",
                table: "ORGANIZATION",
                column: "OrganizationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APPROVAL_ROUTE");

            migrationBuilder.DropTable(
                name: "ORGANIZATION");

            migrationBuilder.DropColumn(
                name: "SALT",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "ADDRESS",
                table: "COMPANY");
        }
    }
}
