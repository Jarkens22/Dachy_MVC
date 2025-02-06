using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dachy.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addSessionIdToOrderHeaderDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                table: "OrderHeader",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "OrderHeader");
        }
    }
}
