
using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvAnalyzer.WebApi.Migrations
{
    public partial class addusersearchqueryadvertisement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "SearchQuery",
                columns: table => new
                {
                    SearchQueryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshFrequency = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchQuery", x => x.SearchQueryId);
                    table.ForeignKey(
                        name: "FK_SearchQuery_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Advertisement",
                columns: table => new
                {
                    AdvertisementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFavorite = table.Column<bool>(type: "bit", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SearchQueryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisement", x => x.AdvertisementId);
                    table.ForeignKey(
                        name: "FK_Advertisement_SearchQuery_SearchQueryId",
                        column: x => x.SearchQueryId,
                        principalTable: "SearchQuery",
                        principalColumn: "SearchQueryId");
                    table.ForeignKey(
                        name: "FK_Advertisement_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_SearchQueryId",
                table: "Advertisement",
                column: "SearchQueryId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_UserId",
                table: "Advertisement",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SearchQuery_UserId",
                table: "SearchQuery",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advertisement");

            migrationBuilder.DropTable(
                name: "SearchQuery");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
