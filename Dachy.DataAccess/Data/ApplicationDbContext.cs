using Dachy.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dachy.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<OrderHeader> OrderHeader { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Pokrycia stalowe", DisplayOrder = 1 },
                new Category { CategoryId = 2, Name = "Dachówki ceramiczne", DisplayOrder = 2 },
                new Category { CategoryId = 3, Name = "Dachówki cementowe", DisplayOrder = 3 },
                new Category { CategoryId = 4, Name = "Systemy rynnowe", DisplayOrder = 4 },
                new Category { CategoryId = 5, Name = "Akcesoria", DisplayOrder = 5 }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Name = "Frigge",
                    Description = "Frigge to nowoczesny i estetyczny dach na każdą kieszeń. Prosta, ciekawa forma oraz szeroki wybór powłok i kolorów blachodachówki modułowej Ruukki Frigge – to cechy, które pozwolą spełnić oczekiwania każdego Klienta.",
                    Producent = "Ruukki",
                    ListPrice = 55,
                    Price100 = 52,
                    Price300 = 49,
                    Price500 = 46,
                    CategoryId = 1                },
                new Product
                {
                    ProductId = 2,
                    Name = "Como",
                    Description = "Wolność i swoboda w działaniu - to Como! Dopasuj powierzchnię dachu do własnego gustu i wybierz wersję standardową bądź z dodatkowym przetłoczeniem - mikrofalą.",
                    Producent = "BudMat",
                    ListPrice = 60,
                    Price100 = 57,
                    Price300 = 54,
                    Price500 = 51,
                    CategoryId = 1                },
                new Product
                {
                    ProductId = 3,
                    Name = "Venecja",
                    Description = "Pierwsza w rodzinie. Od niej wszystko się zaczęło. To efekt pracy nad najlepszym dachem modułowym w Polsce i w Europie. 5 dolnych fal i 6 wierzchołków sprawiają, że Venecja podkreśla urodę klasycznych budynków.",
                    Producent = "BudMat",
                    ListPrice = 66,
                    Price100 = 62,
                    Price300 = 59,
                    Price500 = 56,
                    CategoryId = 1
                }
                );

        }

    }
}
