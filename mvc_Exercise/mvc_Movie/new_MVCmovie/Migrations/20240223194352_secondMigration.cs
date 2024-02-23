using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace new_MVCmovie.Migrations
{
    /// <inheritdoc />
    public partial class secondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Movie_MovieId",
                table: "Artist");

            migrationBuilder.DropIndex(
                name: "IX_Artist_MovieId",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Artist");

            migrationBuilder.CreateTable(
                name: "ArtistMovie",
                columns: table => new
                {
                    ArtistsArtistId = table.Column<int>(type: "INTEGER", nullable: false),
                    MoviesMovieId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistMovie", x => new { x.ArtistsArtistId, x.MoviesMovieId });
                    table.ForeignKey(
                        name: "FK_ArtistMovie_Artist_ArtistsArtistId",
                        column: x => x.ArtistsArtistId,
                        principalTable: "Artist",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistMovie_Movie_MoviesMovieId",
                        column: x => x.MoviesMovieId,
                        principalTable: "Movie",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistMovie_MoviesMovieId",
                table: "ArtistMovie",
                column: "MoviesMovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistMovie");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Artist",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artist_MovieId",
                table: "Artist",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_Movie_MovieId",
                table: "Artist",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "MovieId");
        }
    }
}
