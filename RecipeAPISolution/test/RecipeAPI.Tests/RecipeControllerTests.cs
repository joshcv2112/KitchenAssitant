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

        [Fact]
        public void GetCommandItems_ReturnsZeroItems_WhenDBIsEmpty()
        {
            mockRepo.Setup(repo =>
                repo.GetAllRecipes()).Returns(GetRecipes(0));
            var controller = new RecipesController(mockRepo.Object, mapper);
            var result = controller.GetAllRecipes();
            Assert.IsType<OkObjectResult>(result.Result);
        }

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