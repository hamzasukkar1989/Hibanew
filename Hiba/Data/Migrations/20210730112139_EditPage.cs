using Microsoft.EntityFrameworkCore.Migrations;

namespace Hiba.Data.Migrations
{
    public partial class EditPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PageName",
                table: "Pages",
                newName: "Title2");

            migrationBuilder.AddColumn<string>(
                name: "Title1",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title1",
                table: "Pages");

            migrationBuilder.RenameColumn(
                name: "Title2",
                table: "Pages",
                newName: "PageName");
        }
    }
}
