using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebClient.Migrations
{
    public partial class db0001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "APPROVAL",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CREATE_USER = table.Column<string>(nullable: true),
                    CREATE_DATETIME = table.Column<DateTime>(nullable: false),
                    UPDATE_USER = table.Column<string>(nullable: true),
                    UPDATE_DATETIME = table.Column<DateTime>(nullable: false),
                    NO = table.Column<string>(nullable: true),
                    COMP_ID = table.Column<int>(nullable: false),
                    SLIP_NO = table.Column<string>(nullable: true),
                    APPLICATION_DATETIME = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APPROVAL", x => x.ID);
                });

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
                name: "COMPANY",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CREATE_USER = table.Column<string>(nullable: true),
                    CREATE_DATETIME = table.Column<DateTime>(nullable: false),
                    UPDATE_USER = table.Column<string>(nullable: true),
                    UPDATE_DATETIME = table.Column<DateTime>(nullable: false),
                    CODE = table.Column<string>(nullable: true),
                    NAME = table.Column<string>(nullable: true),
                    ADDRESS = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPANY", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CREATE_USER = table.Column<string>(nullable: true),
                    CREATE_DATETIME = table.Column<DateTime>(nullable: false),
                    UPDATE_USER = table.Column<string>(nullable: true),
                    UPDATE_DATETIME = table.Column<DateTime>(nullable: false),
                    CODE = table.Column<string>(nullable: true),
                    NAME = table.Column<string>(nullable: true),
                    MAIL = table.Column<string>(nullable: true),
                    PASSWORD = table.Column<string>(nullable: true),
                    SALT = table.Column<byte[]>(nullable: true),
                    ICON = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.ID);
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

            migrationBuilder.CreateTable(
                name: "EMPLOYEE",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CREATE_USER = table.Column<string>(nullable: true),
                    CREATE_DATETIME = table.Column<DateTime>(nullable: false),
                    UPDATE_USER = table.Column<string>(nullable: true),
                    UPDATE_DATETIME = table.Column<DateTime>(nullable: false),
                    COMPANY_ID = table.Column<Guid>(nullable: false),
                    USER_ID = table.Column<Guid>(nullable: false),
                    POSITION = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EMPLOYEE_COMPANY_COMPANY_ID",
                        column: x => x.COMPANY_ID,
                        principalTable: "COMPANY",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EMPLOYEE_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEE_COMPANY_ID",
                table: "EMPLOYEE",
                column: "COMPANY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEE_USER_ID",
                table: "EMPLOYEE",
                column: "USER_ID");

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
                name: "APPROVAL");

            migrationBuilder.DropTable(
                name: "APPROVAL_ROUTE");

            migrationBuilder.DropTable(
                name: "EMPLOYEE");

            migrationBuilder.DropTable(
                name: "ORGANIZATION");

            migrationBuilder.DropTable(
                name: "USER");

            migrationBuilder.DropTable(
                name: "COMPANY");
        }
    }
}
