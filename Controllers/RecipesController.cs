using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RecipeApi.Models;
using RecipeApi.Data;

namespace RecipeApi.Controllers
{
    [Route("api/recipes")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeRepo _repository;

        public RecipesController(IRecipeRepo repository)
        {
            _repository = repository;
        }

        //GET api/recipes
        [HttpGet]
        public ActionResult<IEnumerable<Recipe>> GetAllRecipes()
        {
            var commandItems = _repository.GetAppCommands();

            return Ok(commandItems);
        }

        //GET api/recipes/{id}
        [HttpGet("{id}")]
        public ActionResult<Recipe> GetRecipeById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            return Ok(commandItem);
        }
    }
}