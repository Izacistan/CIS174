using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OlympicFlags.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    GamesID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GamesName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.GamesID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GamesID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CategoryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CountryFlag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                    table.ForeignKey(
                        name: "FK_Countries_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Countries_Game_GamesID",
                        column: x => x.GamesID,
                        principalTable: "Game",
                        principalColumn: "GamesID");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[,]
                {
                    { "indoor", "Indoor" },
                    { "outdoor", "Outdoor" }
                });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "GamesID", "GamesName" },
                values: new object[,]
                {
                    { "paralympic", "Paralympic Games" },
                    { "summer", "Summer Olympics" },
                    { "winter", "Winter Olympics" },
                    { "youth", "Youth Olympic Games" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "CategoryID", "CountryFlag", "CountryName", "GamesID" },
                values: new object[,]
                {
                    { "abw", "outdoor", "netherlands.jpg", "Netherlands", "summer" },
                    { "aut", "outdoor", "austria.jpg", "Austria", "paralympic" },
                    { "bra", "outdoor", "brazil.jpg", "Brazil", "summer" },
                    { "can", "indoor", "canada.jpg", "Canada", "winter" },
                    { "chn", "indoor", "china.jpg", "China", "summer" },
                    { "cyp", "indoor", "cyprus.jpg", "Cyrpus", "youth" },
                    { "deu", "indoor", "germany.jpg", "Germany", "summer" },
                    { "fin", "outdoor", "finland.jpg", "Finland", "youth" },
                    { "fra", "indoor", "france.jpg", "France", "youth" },
                    { "gbr", "indoor", "great_britain.jpg", "Great Britain", "winter" },
                    { "ita", "outdoor", "italy.jpg", "Italy", "winter" },
                    { "jam", "outdoor", "jamaica.jpg", "Jamaica", "winter" },
                    { "jpn", "outdoor", "japan.jpg", "Japan", "winter" },
                    { "mex", "indoor", "mexico.jpg", "Mexico", "summer" },
                    { "pak", "outdoor", "pakistan.jpg", "Pakistan", "paralympic" },
                    { "prt", "outdoor", "portugal.jpg", "Portugal", "youth" },
                    { "rus", "indoor", "russia.jpg", "Russia", "youth" },
                    { "svk", "outdoor", "slovakia.jpg", "Slovakia", "youth" },
                    { "swe", "indoor", "sweden.jpg", "Sweden", "winter" },
                    { "tha", "indoor", "thailand.jpg", "Thailand", "paralympic" },
                    { "ukr", "indoor", "ukraine.jpg", "Ukraine", "paralympic" },
                    { "ury", "indoor", "uruguay.jpg", "Uruguay", "paralympic" },
                    { "usa", "outdoor", "united_states.jpg", "United States", "summer" },
                    { "zwe", "outdoor", "zimbabwe.jpg", "Zimbabwe", "paralympic" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CategoryID",
                table: "Countries",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_GamesID",
                table: "Countries",
                column: "GamesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Game");
        }
    }
}
