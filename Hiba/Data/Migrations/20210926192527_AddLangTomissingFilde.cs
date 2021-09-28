using Microsoft.EntityFrameworkCore.Migrations;

namespace Hiba.Data.Migrations
{
    public partial class AddLangTomissingFilde : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Lang",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lang",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lang",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lang",
                table: "Banners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lang",
                table: "AddToYourInformation",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lang",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Lang",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Lang",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Lang",
                table: "Banners");

            migrationBuilder.DropColumn(
                name: "Lang",
                table: "AddToYourInformation");
        }
    }
}
