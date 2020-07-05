using RecipeAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System;

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
            if (rcp == null)
            {
                throw new ArgumentNullException(nameof(rcp));
            }
            _context.RecipeItems.Add(rcp);
        }

        public void DeleteRecipe(Recipe rcp)
        {
            if (rcp == null)
            {
                throw new ArgumentNullException(nameof(rcp));
            }
            _context.RecipeItems.Remove(rcp);
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
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateRecipe(Recipe rcp)
        {
            // We don't need to do anything, here...
        }
    }
}