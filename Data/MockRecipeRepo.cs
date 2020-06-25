using System.Collections.Generic;
using RecipeApi.Models;

namespace RecipeApi.Data
{
    public class MockRecipeRepo : IRecipeRepo
    {
        public IEnumerable<Recipe> GetAppCommands()
        {
            var recipes = new List<Recipe>
            {
                new Recipe{Id=0, Name="Scrambled Eggs", Description="Eggs, Salt, Pepper", Rating=10},
                new Recipe{Id=1, Name="Toast", Description="Bread, Toaster, Butter", Rating=9},
                new Recipe{Id=2, Name="French Fries", Description="Potatoes, Salt, Oil", Rating=10},
            };

            return recipes;
        }

        public Recipe GetCommandById(int id)
        {
            return new Recipe { Id = 2, Name = "French Fries", Description = "Potatoes, Salt, Oil", Rating = 10 };
        }
    }
}