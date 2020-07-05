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

        [HttpGet("{id}", Name = "GetRecipeById")]
        public ActionResult<RecipeReadDto> GetRecipeById(int id)
        {
            var recipeItem = _repository.GetRecipeById(id);
            if (recipeItem == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<RecipeReadDto>(recipeItem));
        }

        [HttpPost]
        public ActionResult<RecipeReadDto> CreateRecipe(RecipeCreateDto recipeCreateDto)
        {
            var recipeModel = _mapper.Map<Recipe>(recipeCreateDto);
            _repository.CreateRecipe(recipeModel);
            _repository.SaveChanges();

            var RecipeReadDto = _mapper.Map<RecipeReadDto>(recipeModel);

            return CreatedAtRoute(nameof(GetRecipeById),
                new { Id = RecipeReadDto.Id }, RecipeReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateRecipe(int id, RecipeUpdateDto recipeUpdateDto)
        {
            var recipeModelFromRepo = _repository.GetRecipeById(id);
            if (recipeModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(recipeUpdateDto, recipeModelFromRepo);
            _repository.UpdateRecipe(recipeModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}