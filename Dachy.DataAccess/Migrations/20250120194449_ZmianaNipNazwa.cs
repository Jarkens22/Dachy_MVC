using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dachy.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ZmianaNipNazwa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NIP",
                table: "Companies",
                newName: "Nip");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nip",
                table: "Companies",
                newName: "NIP");
        }
    }
}
