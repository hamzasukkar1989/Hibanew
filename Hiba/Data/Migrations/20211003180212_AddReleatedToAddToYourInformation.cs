using Microsoft.EntityFrameworkCore.Migrations;

namespace Hiba.Data.Migrations
{
    public partial class AddReleatedToAddToYourInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddToYourInformationID",
                table: "AddToYourInformation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AddToYourInformation_AddToYourInformationID",
                table: "AddToYourInformation",
                column: "AddToYourInformationID");

            migrationBuilder.AddForeignKey(
                name: "FK_AddToYourInformation_AddToYourInformation_AddToYourInformationID",
                table: "AddToYourInformation",
                column: "AddToYourInformationID",
                principalTable: "AddToYourInformation",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddToYourInformation_AddToYourInformation_AddToYourInformationID",
                table: "AddToYourInformation");

            migrationBuilder.DropIndex(
                name: "IX_AddToYourInformation_AddToYourInformationID",
                table: "AddToYourInformation");

            migrationBuilder.DropColumn(
                name: "AddToYourInformationID",
                table: "AddToYourInformation");
        }
    }
}
