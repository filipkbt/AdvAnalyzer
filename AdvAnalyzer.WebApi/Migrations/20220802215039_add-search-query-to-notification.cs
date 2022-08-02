using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvAnalyzer.WebApi.Migrations
{
    public partial class addsearchquerytonotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SearchQueryId",
                table: "Notification",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Notification_SearchQueryId",
                table: "Notification",
                column: "SearchQueryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_SearchQuery_SearchQueryId",
                table: "Notification",
                column: "SearchQueryId",
                principalTable: "SearchQuery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_SearchQuery_SearchQueryId",
                table: "Notification");

            migrationBuilder.DropIndex(
                name: "IX_Notification_SearchQueryId",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "SearchQueryId",
                table: "Notification");
        }
    }
}
