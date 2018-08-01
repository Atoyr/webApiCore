using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebClient.Migrations
{
    public partial class db0002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Companys_CompanyId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Users_UserId1",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_UserId1",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companys",
                table: "Companys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Approvals",
                table: "Approvals");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "USER");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "EMPLOYEE");

            migrationBuilder.RenameTable(
                name: "Companys",
                newName: "COMPANY");

            migrationBuilder.RenameTable(
                name: "Approvals",
                newName: "APPROVAL");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "USER",
                newName: "PASSWORD");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "USER",
                newName: "NAME");

            migrationBuilder.RenameColumn(
                name: "Mail",
                table: "USER",
                newName: "MAIL");

            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "USER",
                newName: "ICON");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "USER",
                newName: "CODE");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "USER",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "EMPLOYEE",
                newName: "POSITION");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "EMPLOYEE",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "EMPLOYEE",
                newName: "USER_ID");

            migrationBuilder.RenameColumn(
                name: "UpdateUser",
                table: "EMPLOYEE",
                newName: "UPDATE_USER");

            migrationBuilder.RenameColumn(
                name: "UpdateDateTime",
                table: "EMPLOYEE",
                newName: "UPDATE_DATETIME");

            migrationBuilder.RenameColumn(
                name: "CreateUser",
                table: "EMPLOYEE",
                newName: "CREATE_USER");

            migrationBuilder.RenameColumn(
                name: "CreateDateTime",
                table: "EMPLOYEE",
                newName: "CREATE_DATETIME");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "EMPLOYEE",
                newName: "COMPANY_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_CompanyId",
                table: "EMPLOYEE",
                newName: "IX_EMPLOYEE_COMPANY_ID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "COMPANY",
                newName: "NAME");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "COMPANY",
                newName: "CODE");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "COMPANY",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "UpdateUser",
                table: "COMPANY",
                newName: "UPDATE_USER");

            migrationBuilder.RenameColumn(
                name: "UpdateDateTime",
                table: "COMPANY",
                newName: "UPDATE_DATETIME");

            migrationBuilder.RenameColumn(
                name: "CreateUser",
                table: "COMPANY",
                newName: "CREATE_USER");

            migrationBuilder.RenameColumn(
                name: "CreateDateTime",
                table: "COMPANY",
                newName: "CREATE_DATETIME");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "APPROVAL",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "SlipNo",
                table: "APPROVAL",
                newName: "SLIP_NO");

            migrationBuilder.RenameColumn(
                name: "CompId",
                table: "APPROVAL",
                newName: "COMP_ID");

            migrationBuilder.RenameColumn(
                name: "ApprovalNo",
                table: "APPROVAL",
                newName: "UPDATE_USER");

            migrationBuilder.RenameColumn(
                name: "ApplicationDate",
                table: "APPROVAL",
                newName: "UPDATE_DATETIME");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "USER",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATE_DATETIME",
                table: "USER",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CREATE_USER",
                table: "USER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATE_DATETIME",
                table: "USER",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UPDATE_USER",
                table: "USER",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "EMPLOYEE",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<Guid>(
                name: "USER_ID",
                table: "EMPLOYEE",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATE_DATETIME",
                table: "EMPLOYEE",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "COMPANY_ID",
                table: "EMPLOYEE",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "COMPANY",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATE_DATETIME",
                table: "COMPANY",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "APPROVAL",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "APPLICATION_DATETIME",
                table: "APPROVAL",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATE_DATETIME",
                table: "APPROVAL",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CREATE_USER",
                table: "APPROVAL",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NO",
                table: "APPROVAL",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_USER",
                table: "USER",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EMPLOYEE",
                table: "EMPLOYEE",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_COMPANY",
                table: "COMPANY",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_APPROVAL",
                table: "APPROVAL",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEE_USER_ID",
                table: "EMPLOYEE",
                column: "USER_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_EMPLOYEE_COMPANY_COMPANY_ID",
                table: "EMPLOYEE",
                column: "COMPANY_ID",
                principalTable: "COMPANY",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EMPLOYEE_USER_USER_ID",
                table: "EMPLOYEE",
                column: "USER_ID",
                principalTable: "USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EMPLOYEE_COMPANY_COMPANY_ID",
                table: "EMPLOYEE");

            migrationBuilder.DropForeignKey(
                name: "FK_EMPLOYEE_USER_USER_ID",
                table: "EMPLOYEE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_USER",
                table: "USER");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EMPLOYEE",
                table: "EMPLOYEE");

            migrationBuilder.DropIndex(
                name: "IX_EMPLOYEE_USER_ID",
                table: "EMPLOYEE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_COMPANY",
                table: "COMPANY");

            migrationBuilder.DropPrimaryKey(
                name: "PK_APPROVAL",
                table: "APPROVAL");

            migrationBuilder.DropColumn(
                name: "CREATE_DATETIME",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "CREATE_USER",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "UPDATE_DATETIME",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "UPDATE_USER",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "APPLICATION_DATETIME",
                table: "APPROVAL");

            migrationBuilder.DropColumn(
                name: "CREATE_DATETIME",
                table: "APPROVAL");

            migrationBuilder.DropColumn(
                name: "CREATE_USER",
                table: "APPROVAL");

            migrationBuilder.DropColumn(
                name: "NO",
                table: "APPROVAL");

            migrationBuilder.RenameTable(
                name: "USER",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "EMPLOYEE",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "COMPANY",
                newName: "Companys");

            migrationBuilder.RenameTable(
                name: "APPROVAL",
                newName: "Approvals");

            migrationBuilder.RenameColumn(
                name: "PASSWORD",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "NAME",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "MAIL",
                table: "Users",
                newName: "Mail");

            migrationBuilder.RenameColumn(
                name: "ICON",
                table: "Users",
                newName: "Icon");

            migrationBuilder.RenameColumn(
                name: "CODE",
                table: "Users",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "POSITION",
                table: "Employees",
                newName: "Position");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Employees",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "USER_ID",
                table: "Employees",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UPDATE_USER",
                table: "Employees",
                newName: "UpdateUser");

            migrationBuilder.RenameColumn(
                name: "UPDATE_DATETIME",
                table: "Employees",
                newName: "UpdateDateTime");

            migrationBuilder.RenameColumn(
                name: "CREATE_USER",
                table: "Employees",
                newName: "CreateUser");

            migrationBuilder.RenameColumn(
                name: "CREATE_DATETIME",
                table: "Employees",
                newName: "CreateDateTime");

            migrationBuilder.RenameColumn(
                name: "COMPANY_ID",
                table: "Employees",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_EMPLOYEE_COMPANY_ID",
                table: "Employees",
                newName: "IX_Employees_CompanyId");

            migrationBuilder.RenameColumn(
                name: "NAME",
                table: "Companys",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CODE",
                table: "Companys",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Companys",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UPDATE_USER",
                table: "Companys",
                newName: "UpdateUser");

            migrationBuilder.RenameColumn(
                name: "UPDATE_DATETIME",
                table: "Companys",
                newName: "UpdateDateTime");

            migrationBuilder.RenameColumn(
                name: "CREATE_USER",
                table: "Companys",
                newName: "CreateUser");

            migrationBuilder.RenameColumn(
                name: "CREATE_DATETIME",
                table: "Companys",
                newName: "CreateDateTime");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Approvals",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SLIP_NO",
                table: "Approvals",
                newName: "SlipNo");

            migrationBuilder.RenameColumn(
                name: "COMP_ID",
                table: "Approvals",
                newName: "CompId");

            migrationBuilder.RenameColumn(
                name: "UPDATE_USER",
                table: "Approvals",
                newName: "ApprovalNo");

            migrationBuilder.RenameColumn(
                name: "UPDATE_DATETIME",
                table: "Approvals",
                newName: "ApplicationDate");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Users",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(Guid))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDateTime",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Employees",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Companys",
                nullable: false,
                oldClrType: typeof(Guid))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDateTime",
                table: "Companys",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Approvals",
                nullable: false,
                oldClrType: typeof(Guid))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companys",
                table: "Companys",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Approvals",
                table: "Approvals",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId1",
                table: "Employees",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Companys_CompanyId",
                table: "Employees",
                column: "CompanyId",
                principalTable: "Companys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_UserId1",
                table: "Employees",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
