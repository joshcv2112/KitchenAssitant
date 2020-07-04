using RecipeAPI.Models;
using System.Collections.Generic;
using System.Linq;


namespace RecipeAPI.Data
{
    public class SqlRecipeAPIRepo : IRecipeAPIRepo
    {
        private readonly RecipeContext _context;

        public SqlRecipeAPIRepo(RecipeContext context)
        {
            _context = context;
        }

        public void CreateRecipe(Recipe rcp)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteRecipe(Recipe rcp)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Recipe> GetAllRecipes()
        {
            return _context.RecipeItems.ToList();
        }

        public Recipe GetRecipeById(int id)
        {
            return _context.RecipeItems.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateRecipe(Recipe rcp)
        {
            throw new System.NotImplementedException();
        }
    }
}