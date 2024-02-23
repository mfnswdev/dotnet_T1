using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcMovie.Migrations
{
    /// <inheritdoc />
    public partial class _4Migration : Migration
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
                    Artistsid = table.Column<int>(type: "INTEGER", nullable: false),
                    MoviesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistMovie", x => new { x.Artistsid, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_ArtistMovie_Artist_Artistsid",
                        column: x => x.Artistsid,
                        principalTable: "Artist",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistMovie_Movie_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistMovie_MoviesId",
                table: "ArtistMovie",
                column: "MoviesId");
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
                principalColumn: "Id");
        }
    }
}
