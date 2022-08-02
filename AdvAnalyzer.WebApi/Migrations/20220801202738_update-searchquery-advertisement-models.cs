using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvAnalyzer.WebApi.Migrations
{
    public partial class updatesearchqueryadvertisementmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInitialized",
                table: "SearchQuery",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Advertisement",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInitialized",
                table: "SearchQuery");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Advertisement");
        }
    }
}
