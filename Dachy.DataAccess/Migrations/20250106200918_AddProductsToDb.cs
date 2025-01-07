using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dachy.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddProductsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Producent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false),
                    Price300 = table.Column<double>(type: "float", nullable: false),
                    Price500 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "ListPrice", "Name", "Price100", "Price300", "Price500", "Producent" },
                values: new object[,]
                {
                    { 1, "Frigge to nowoczesny i estetyczny dach na każdą kieszeń. Prosta, ciekawa forma oraz szeroki wybór powłok i kolorów blachodachówki modułowej Ruukki Frigge – to cechy, które pozwolą spełnić oczekiwania każdego Klienta.", 55.0, "Frigge", 52.0, 49.0, 46.0, "Ruukki" },
                    { 2, "Wolność i swoboda w działaniu - to Como! Dopasuj powierzchnię dachu do własnego gustu i wybierz wersję standardową bądź z dodatkowym przetłoczeniem - mikrofalą.", 60.0, "Como", 57.0, 54.0, 51.0, "BudMat" },
                    { 3, "Pierwsza w rodzinie. Od niej wszystko się zaczęło. To efekt pracy nad najlepszym dachem modułowym w Polsce i w Europie. 5 dolnych fal i 6 wierzchołków sprawiają, że Venecja podkreśla urodę klasycznych budynków.", 66.0, "Venecja", 62.0, 59.0, 56.0, "BudMat" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
