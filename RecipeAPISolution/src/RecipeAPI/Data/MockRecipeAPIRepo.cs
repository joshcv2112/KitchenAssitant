using System.Collections.Generic;
using RecipeAPI.Models;

namespace RecipeAPI.Data
{
    public class MockRecipeAPIRepo : IRecipeAPIRepo
    {
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
            var recipes = new List<Recipe>
            {
                new Recipe{Id = 0, Title="My First Recipe",
                           Ingredients="Potatoes, Cheese",
                           Instructions="",
                           Description="",
                           Source="",
                           Rating=5,
                           PrepTime="5 min"
                           },
                new Recipe{Id = 1, Title="My First Recipe",
                           Ingredients="Potatoes, Cheese",
                           Instructions="",
                           Description="",
                           Source="",
                           Rating=5,
                           PrepTime="5 min"
                           },
                new Recipe{Id = 2, Title="My First Recipe",
                           Ingredients="Potatoes, Cheese",
                           Instructions="",
                           Description="",
                           Source="",
                           Rating=5,
                           PrepTime="5 min"
                           },
            };
            return recipes;
        }

        public Recipe GetRecipeById(int id)
        {
            return new Recipe
            {
                Ingredients = "Potatoes, Cheese",
                Instructions = "",
                Description = "",
                Source = "",
                Rating = 5,
                PrepTime = "5 min"
            };
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