using ITSolutionsCompanyV1.Data.Extensions;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ITSolutionsCompanyV1.Migrations
{
    public partial class unique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Tasks_Name",
                table: "Tasks",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Projects_Name",
                table: "Projects",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Projects_Name1",
                table: "Projects",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Documentation_Name",
                table: "Documentation",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Demos_Name",
                table: "Demos",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanyName_Pib",
                table: "AspNetUsers",
                columns: new[] { "CompanyName", "Pib" },
                unique: true,
                filter: "[CompanyName] IS NOT NULL AND [Pib] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Tasks_Name",
                table: "Tasks");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Projects_Name",
                table: "Projects");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Projects_Name1",
                table: "Projects");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Documentation_Name",
                table: "Documentation");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Demos_Name",
                table: "Demos");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CompanyName_Pib",
                table: "AspNetUsers");
        }
    }
}
