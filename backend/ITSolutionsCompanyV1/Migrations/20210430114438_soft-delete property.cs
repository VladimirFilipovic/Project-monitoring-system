using Microsoft.EntityFrameworkCore.Migrations;

namespace ITSolutionsCompanyV1.Migrations
{
    public partial class softdeleteproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documentations_AspNetUsers_EmployeeId",
                table: "Documentations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Documentations",
                table: "Documentations");

            migrationBuilder.RenameTable(
                name: "Documentations",
                newName: "Documentation");

            migrationBuilder.RenameIndex(
                name: "IX_Documentations_EmployeeId",
                table: "Documentation",
                newName: "IX_Documentation_EmployeeId");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Tasks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Requests",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Projects",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Payments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "EmployeeTask",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Demos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "AspNetRoles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Documentation",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Documentation",
                table: "Documentation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documentation_AspNetUsers_EmployeeId",
                table: "Documentation",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documentation_AspNetUsers_EmployeeId",
                table: "Documentation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Documentation",
                table: "Documentation");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "EmployeeTask");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Demos");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Documentation");

            migrationBuilder.RenameTable(
                name: "Documentation",
                newName: "Documentations");

            migrationBuilder.RenameIndex(
                name: "IX_Documentation_EmployeeId",
                table: "Documentations",
                newName: "IX_Documentations_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Documentations",
                table: "Documentations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documentations_AspNetUsers_EmployeeId",
                table: "Documentations",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
