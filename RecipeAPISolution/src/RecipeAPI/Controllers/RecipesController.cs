using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RecipeAPI.Data;
using RecipeAPI.Models;

namespace RecipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeAPIRepo _repository;

        public RecipesController(IRecipeAPIRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Recipe>> GetAllRecipes()
        {
            var recipeItems = _repository.GetAllRecipes();

            return Ok(recipeItems);
        }

        [HttpGet("{id}")]
        public ActionResult<Recipe> GetRecipeById(int id)
        {
            var recipeItem = _repository.GetRecipeById(id);
            if (recipeItem == null)
            {
                return NotFound();
            }
            return Ok(recipeItem);
        }
    }
}