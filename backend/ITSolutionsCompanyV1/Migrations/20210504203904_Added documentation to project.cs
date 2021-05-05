using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ITSolutionsCompanyV1.Migrations
{
    public partial class Addeddocumentationtoproject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsCompleted",
                table: "Projects",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "Documentation",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Documentation_ProjectId",
                table: "Documentation",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documentation_Projects_ProjectId",
                table: "Documentation",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documentation_Projects_ProjectId",
                table: "Documentation");

            migrationBuilder.DropIndex(
                name: "IX_Documentation_ProjectId",
                table: "Documentation");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Documentation");

            migrationBuilder.AlterColumn<bool>(
                name: "IsCompleted",
                table: "Projects",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);
        }
    }
}
