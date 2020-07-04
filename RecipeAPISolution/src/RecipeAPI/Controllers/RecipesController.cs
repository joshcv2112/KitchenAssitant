using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RecipeAPI.Data;
using RecipeAPI.Models;
using AutoMapper;
using RecipeAPI.Dtos;


namespace RecipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeAPIRepo _repository;
        private readonly IMapper _mapper;

        public RecipesController(IRecipeAPIRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RecipeReadDto>> GetAllRecipes()
        {
            var recipeItems = _repository.GetAllRecipes();
            return Ok(_mapper.Map<IEnumerable<RecipeReadDto>>(recipeItems));
        }

        [HttpGet("{id}")]
        public ActionResult<RecipeReadDto> GetRecipeById(int id)
        {
            var recipeItem = _repository.GetRecipeById(id);
            if (recipeItem == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<RecipeReadDto>(recipeItem));
        }
    }
}