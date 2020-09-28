using Microsoft.EntityFrameworkCore.Migrations;

namespace ChrisCafe.Data.Migrations
{
    public partial class SubcategorySortOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SortPosition",
                table: "Subcategory",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SortPosition",
                table: "Subcategory");
        }
    }
}
