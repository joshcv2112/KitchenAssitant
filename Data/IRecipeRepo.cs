using System.Collections.Generic;
using RecipeApi.Models;

namespace RecipeApi.Data
{
    public interface IRecipeRepo
    {
        IEnumerable<Recipe> GetAppCommands();
        Recipe GetCommandById(int id);
    }
}