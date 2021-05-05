using Microsoft.EntityFrameworkCore.Migrations;

namespace ITSolutionsCompanyV1.Migrations
{
    public partial class AddSeedingTracking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "AccountIsActive",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.CreateTable(
                name: "SeedingEntries",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeedingEntries", x => x.Name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeedingEntries");

            migrationBuilder.AlterColumn<bool>(
                name: "AccountIsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldDefaultValue: true);
        }
    }
}
