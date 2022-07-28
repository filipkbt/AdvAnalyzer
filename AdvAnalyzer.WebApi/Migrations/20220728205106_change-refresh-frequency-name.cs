using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvAnalyzer.WebApi.Migrations
{
    public partial class changerefreshfrequencyname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RefreshFrequency",
                table: "SearchQuery",
                newName: "RefreshFrequencyInMinutes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RefreshFrequencyInMinutes",
                table: "SearchQuery",
                newName: "RefreshFrequency");
        }
    }
}
