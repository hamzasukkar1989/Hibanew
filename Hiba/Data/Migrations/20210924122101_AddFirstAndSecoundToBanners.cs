using Microsoft.EntityFrameworkCore.Migrations;

namespace Hiba.Data.Migrations
{
    public partial class AddFirstAndSecoundToBanners : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "First",
                table: "Banners",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Secound",
                table: "Banners",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "First",
                table: "Banners");

            migrationBuilder.DropColumn(
                name: "Secound",
                table: "Banners");
        }
    }
}
