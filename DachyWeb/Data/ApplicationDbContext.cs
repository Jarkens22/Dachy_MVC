using DachyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace DachyWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Pokrycia stalowe", DisplayOrder = 1 },
                new Category { CategoryId = 2, Name = "Dachówki ceramiczne", DisplayOrder = 2 },
                new Category { CategoryId = 3, Name = "Dachówki cementowe", DisplayOrder = 3 },
                new Category { CategoryId = 4, Name = "Systemy rynnowe", DisplayOrder = 4 },
                new Category { CategoryId = 5, Name = "Akcesoria", DisplayOrder = 5 }
                );
        }
    }
}
