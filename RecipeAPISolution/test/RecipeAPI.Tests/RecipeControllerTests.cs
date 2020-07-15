using System;
using System.Collections.Generic;
using Moq;
using AutoMapper;
using RecipeAPI.Models;
using RecipeAPI.Data;
using RecipeAPI.Profiles;
using RecipeAPI.Dtos;
using RecipeAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;


namespace RecipeAPI.Tests
{
    public class RecipeControllerTests : IDisposable
    {
        Mock<IRecipeAPIRepo> mockRepo;
        RecipesProfile realProfile;
        MapperConfiguration configuration;
        IMapper mapper;

        public RecipeControllerTests()
        {
            mockRepo = new Mock<IRecipeAPIRepo>();
            realProfile = new RecipesProfile();
            configuration = new MapperConfiguration(cfg => cfg.AddProfile(realProfile));
            mapper = new Mapper(configuration);
        }

        public void Dispose()
        {
            mockRepo = null;
            mapper = null;
            configuration = null;
            realProfile = null;
        }

        #region GetAllRecipe Tests
        [Fact]
        public void GetAllRecipes_ReturnsZeroItems_WhenDBIsEmpty()
        {
            mockRepo.Setup(repo =>
                repo.GetAllRecipes()).Returns(GetRecipes(0));
            var controller = new RecipesController(mockRepo.Object, mapper);
            var result = controller.GetAllRecipes();
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetAllRecipes_ReturnsOneItem_WhenDBHasOneResource()
        {
            mockRepo.Setup(repo => repo.GetAllRecipes()).Returns(GetRecipes(1));
            var controller = new RecipesController(mockRepo.Object, mapper);
            var result = controller.GetAllRecipes();
            var okResult = result.Result as OkObjectResult;
            var recipes = okResult.Value as List<RecipeReadDto>;
            Assert.Single(recipes);
        }
        #endregion

        #region GetRecipeByID Tests
        [Fact]
        public void GetRecipeByID_Returns404NotFound_WhenNonExistentIDProvided()
        {
            mockRepo.Setup(repo => repo.GetRecipeById(0)).Returns(() => null);
            var controller = new RecipesController(mockRepo.Object, mapper);
            var result = controller.GetRecipeById(1);   
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void GetRecipeById_Returns200OK_WhenValidIDProvided()
        {
            mockRepo.Setup(repo =>
                repo.GetRecipeById(1)).Returns(new Recipe{
                    Id = 1,
                    Title = "mock",
                    Ingredients = "mock",
                    Instructions = "mock",
                    Description = "mock",
                    Source = "mock",
                    Rating = 5,
                    PrepTime = "mock"
                });
            var controller = new RecipesController(mockRepo.Object, mapper);
            var result = controller.GetRecipeById(1);
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetRecipeById_ReturnsRecipeReadDto_WhenValidIDProvided()
        {
            mockRepo.Setup(repo =>
                repo.GetRecipeById(1)).Returns(new Recipe{
                    Id = 1,
                    Title = "mock",
                    Ingredients = "mock",
                    Instructions = "mock",
                    Description = "mock",
                    Source = "mock",
                    Rating = 5,
                    PrepTime = "mock"
                });
            var controller = new RecipesController(mockRepo.Object, mapper);
            var result = controller.GetRecipeById(1);
            Assert.IsType<ActionResult<RecipeReadDto>>(result);
        }
        #endregion

        #region CreateRecipe Tests
        [Fact]
        public void CreateRecipe_ReturnsCorrectResourceType_WhenValidObjectSubmitted()
        {
            mockRepo.Setup(repo => 
                repo.GetRecipeById(1)).Returns(new Recipe { 
                    Id = 1, 
                    Title = "mock",
                    Ingredients = "mock",
                    Instructions = "mock",
                    Description = "mock",
                    Source = "mock",
                    Rating = 5,
                    PrepTime = "mock" });
            var controller = new RecipesController(mockRepo.Object, mapper);
            var result = controller.CreateRecipe(new RecipeCreateDto {});
            Assert.IsType<ActionResult<RecipeReadDto>>(result);
        }

        [Fact]
        public void CreateRecipe_Returns201Created_WhenValidObjectSubmitted()
        {
            mockRepo.Setup(repo =>
                repo.GetRecipeById(1)).Returns(new Recipe { 
                    Id = 1,
                    Title = "mock",
                    Ingredients = "mock",
                    Instructions = "mock",
                    Description = "mock",
                    Source = "mock",
                    Rating = 5,
                    PrepTime = "mock" });
                var controller = new RecipesController(mockRepo.Object, mapper);
                var result = controller.CreateRecipe(new RecipeCreateDto {});
                Assert.IsType<CreatedAtRouteResult>(result.Result);
        }
        #endregion

        #region UpdateRecipe Tests
        [Fact]
        public void UpdateRecipe_Returns204NoContent_WhenValidObjectSubmitted()
        {
            mockRepo.Setup(repo =>
                repo.GetRecipeById(1)).Returns(new Recipe { 
                    Id = 1,
                    Title = "mock",
                    Ingredients = "mock",
                    Instructions = "mock",
                    Description = "mock",
                    Source = "mock",
                    Rating = 5,
                    PrepTime = "mock" });
            var controller = new RecipesController(mockRepo.Object, mapper);
            var result = controller.UpdateRecipe(1, new RecipeUpdateDto {});
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void UpdateRecipe_Returns404NotFound_WhenNonExistentResourceIDSubmitted()
        {
            mockRepo.Setup(repo => repo.GetRecipeById(0)).Returns(() => null);
            var controller = new RecipesController(mockRepo.Object, mapper);
            var result = controller.UpdateRecipe(0, new RecipeUpdateDto {});
            Assert.IsType<NotFoundResult>(result);
        }
        #endregion

        #region PartialRecipeUpdate Tests
        [Fact]
        public void PartialRecipeUpdate_Returns404NotFound_WhenNonExistentResourceIDSubmitted()
        {
            mockRepo.Setup(repo => repo.GetRecipeById(0)).Returns(() => null);
            var controller = new RecipesController(mockRepo.Object, mapper);
            var result = controller.PartialRecipeUpdate(0,
                new Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<RecipeUpdateDto> { });
            Assert.IsType<NotFoundResult>(result);
        }
        #endregion

        #region DeleteRecipe Tests
        [Fact]
        public void DeleteRecipe_Returns204NoContent_WhenValidResourceIDSubmitted()
        {
            mockRepo.Setup(repo =>
                repo.GetRecipeById(1)).Returns(new Recipe { 
                    Id = 1, Title = "mock", Ingredients = "mock", Instructions = "mock",
                    Description = "mock", Source = "mock", Rating = 5, PrepTime = "mock" });
            var controller = new RecipesController(mockRepo.Object, mapper);
            var result = controller.DeleteRecipe(1);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void DeleteRecipe_Returns404NotFound_WhenNonExistentResourceIDSubmitted()
        {
            mockRepo.Setup(repo =>
                repo.GetRecipeById(0)).Returns(() => null);
            var controller = new RecipesController(mockRepo.Object, mapper);
            var result = controller.DeleteRecipe(0);
            Assert.IsType<NotFoundResult>(result);
        }
        #endregion

        private List<Recipe> GetRecipes(int num)
        {
            var recipes = new List<Recipe>();
            if (num > 0)
            {
                recipes.Add(new Recipe
                {
                    Title = "Chicken Parm",
                    Ingredients = "Chicken, Sauce, Cheese",
                    Instructions = "Cook it all together",
                    Description = "Delicious chicken with sauce and cheese",
                    Source = "Family Recipe",
                    Rating = 5,
                    PrepTime = "30 min"
                });
            }
            return recipes;
        }
    }
}