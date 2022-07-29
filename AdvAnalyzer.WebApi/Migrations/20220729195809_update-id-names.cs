using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvAnalyzer.WebApi.Migrations
{
    public partial class updateidnames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "User",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SearchQueryId",
                table: "SearchQuery",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AdvertisementId",
                table: "Advertisement",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SearchQuery",
                newName: "SearchQueryId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Advertisement",
                newName: "AdvertisementId");
        }
    }
}
