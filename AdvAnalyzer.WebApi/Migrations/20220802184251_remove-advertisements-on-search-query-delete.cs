

using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvAnalyzer.WebApi.Migrations
{
    public partial class removeadvertisementsonsearchquerydelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_SearchQuery_SearchQueryId",
                table: "Advertisement");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_SearchQuery_SearchQueryId",
                table: "Advertisement",
                column: "SearchQueryId",
                principalTable: "SearchQuery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_SearchQuery_SearchQueryId",
                table: "Advertisement");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_SearchQuery_SearchQueryId",
                table: "Advertisement",
                column: "SearchQueryId",
                principalTable: "SearchQuery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
