using Microsoft.EntityFrameworkCore;
using RecipeWebStie.Core.Models;

namespace RecipeWebStie.Data
{
    public class DataContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
