using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvAnalyzer.WebApi.Migrations
{
    public partial class addisseentoadvertisement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSeen",
                table: "Advertisement",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSeen",
                table: "Advertisement");
        }
    }
}
