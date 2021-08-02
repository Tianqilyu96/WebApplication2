using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Models
{
    public class RecipesDbContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }

        public RecipesDbContext(DbContextOptions<RecipesDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
