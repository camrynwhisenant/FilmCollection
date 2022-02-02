using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmCollection.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Categoryid = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Categoryid);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: false),
                    Director = table.Column<string>(nullable: false),
                    Year = table.Column<short>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    Edited = table.Column<bool>(nullable: false),
                    LentTo = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(maxLength: 25, nullable: true),
                    Categoryid = table.Column<int>(nullable: false),
                    CategoriesCategoryid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieID);
                    table.ForeignKey(
                        name: "FK_Movies_categories_CategoriesCategoryid",
                        column: x => x.CategoriesCategoryid,
                        principalTable: "categories",
                        principalColumn: "Categoryid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieID", "CategoriesCategoryid", "Categoryid", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 1, null, 4, "Chris Williams", false, "", "", "PG", "Big Hero 6", (short)2014 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieID", "CategoriesCategoryid", "Categoryid", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 2, null, 2, "George Lucas", false, "", "", "PG", "Star Wars: Episode IV - A New Hope", (short)1977 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieID", "CategoriesCategoryid", "Categoryid", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 3, null, 3, "Gus Vant Sant", false, "", "", "R", "Good Will Hunting", (short)1997 });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Categoryid", "CategoryName" },
                values: new object[] { 1, "Action" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Categoryid", "CategoryName" },
                values: new object[] { 2, "Sci-Fi" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Categoryid", "CategoryName" },
                values: new object[] { 3, "Drama" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Categoryid", "CategoryName" },
                values: new object[] { 4, "Family" });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CategoriesCategoryid",
                table: "Movies",
                column: "CategoriesCategoryid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
