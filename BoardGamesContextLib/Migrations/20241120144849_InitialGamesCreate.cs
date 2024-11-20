using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BoardGamesContextLib.Migrations
{
    public partial class InitialGamesCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    YearPublished = table.Column<short>(nullable: false),
                    MinPlayers = table.Column<byte>(nullable: false),
                    MaxPlayers = table.Column<byte>(nullable: false),
                    PlayingTime = table.Column<short>(nullable: false),
                    ImageLink = table.Column<string>(nullable: true),
                    BBGId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Loan",
                columns: table => new
                {
                    LoanID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(nullable: true),
                    GameID = table.Column<int>(nullable: false),
                    BorrowedDate = table.Column<DateTime>(nullable: false),
                    ReturnedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loan", x => x.LoanID);
                });

            migrationBuilder.InsertData(
                table: "GameDetail",
                columns: new[] { "Id", "BBGId", "Description", "ImageLink", "MaxPlayers", "MinPlayers", "Name", "PlayingTime", "YearPublished" },
                values: new object[] { 1, 320, "Carefully place your lettered tiles to make high-scoring words.", "https://boardgamegeek.com/image/404651/scrabble", (byte)4, (byte)2, "Scrabble", (short)90, (short)1948 });

            migrationBuilder.InsertData(
                table: "GameDetail",
                columns: new[] { "Id", "BBGId", "Description", "ImageLink", "MaxPlayers", "MinPlayers", "Name", "PlayingTime", "YearPublished" },
                values: new object[] { 2, 65244, "The island is sinking! Will the brave adventurers save the treasures in time?", "https://boardgamegeek.com/image/646458/forbidden-island", (byte)4, (byte)2, "Forbidden Island", (short)30, (short)2010 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameDetail");

            migrationBuilder.DropTable(
                name: "Loan");
        }
    }
}
