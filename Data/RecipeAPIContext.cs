using RecipeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace RecipeApi.Data
{
    public class RecipeApiContext : DbContext
    {
        public RecipeApiContext(DbContextOptions<RecipeApiContext> opt) : base(opt)
        {

        }

        public DbSet<Recipe> Recipes { get; set; }
    }
}