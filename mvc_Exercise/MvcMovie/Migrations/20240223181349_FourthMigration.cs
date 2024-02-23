using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcMovie.Migrations
{
    /// <inheritdoc />
    public partial class FourthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
