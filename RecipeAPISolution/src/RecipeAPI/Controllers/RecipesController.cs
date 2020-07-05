using System.Collections.Generic;
using AutoMapper;
using RecipeAPI.Dtos;
using RecipeAPI.Data;
using RecipeAPI.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;


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

        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id,
        JsonPatchDocument<RecipeUpdateDto> patchDoc)
        {
            var recipeModelFromRepo = _repository.GetRecipeById(id);
            if (recipeModelFromRepo == null)
            {
                return NotFound();
            }
            var recipeToPatch = _mapper.Map<RecipeUpdateDto>(recipeModelFromRepo);
            patchDoc.ApplyTo(recipeToPatch, ModelState);
            if (!TryValidateModel(recipeToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(recipeToPatch, recipeModelFromRepo);
            _repository.UpdateRecipe(recipeModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteRecipe(int id)
        {
            var recipeModelFromRepo = _repository.GetRecipeById(id);
            if (recipeModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteRecipe(recipeModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}