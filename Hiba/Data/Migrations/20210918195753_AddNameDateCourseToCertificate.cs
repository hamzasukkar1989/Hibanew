using Microsoft.EntityFrameworkCore.Migrations;

namespace Hiba.Data.Migrations
{
    public partial class AddNameDateCourseToCertificate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Course",
                table: "Certificates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Certificates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Certificates",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Course",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Certificates");
        }
    }
}
