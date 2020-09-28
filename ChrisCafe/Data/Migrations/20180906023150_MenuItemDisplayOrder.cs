using Microsoft.EntityFrameworkCore.Migrations;

namespace ChrisCafe.Data.Migrations
{
    public partial class MenuItemDisplayOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "MenuItem",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "MenuItem");
        }
    }
}
