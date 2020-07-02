using System.Collections.Generic;
using RecipeAPI.Models;

namespace RecipeAPI.Data
{
    public interface IRecipeAPIRepo
    {
        bool SaveChanges();

        IEnumerable<Recipe> GetAllRecipes();
        Recipe GetRecipeById(int id);
        void CreateRecipe(Recipe rcp);
        void UpdateRecipe(Recipe rcp);
        void DeleteRecipe(Recipe rcp);
    }
}