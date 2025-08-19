using learn_Razor_Pages.Models;
using Microsoft.EntityFrameworkCore;

namespace learn_Razor_Pages.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        // add-migration AddCategoryTableToDb
        // update-database 
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Category 1", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Category 2", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Category 3", DisplayOrder = 3 }
            );
        }
    }
}
