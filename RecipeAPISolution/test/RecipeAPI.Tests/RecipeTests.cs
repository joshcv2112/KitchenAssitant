using System;
using Xunit;
using RecipeAPI.Models;

namespace RecipeAPI.Tests
{
    public class RecipeTests : IDisposable
    {
        Recipe testRecipe;

        public RecipeTests()
        {
            testRecipe = new Recipe
            {
                Title = "Chicken Parm",
                Ingredients = "Chicken, Sauce, Cheese",
                Instructions = "Cook it all together",
                Description = "Delicious chicken with sauce and cheese",
                Source = "Family Recipe",
                Rating = 5,
                PrepTime = "30 min"
            };
        }

        public void Dispose()
        {
            testRecipe = null;
        }

        [Fact]
        public void CanChangeTitle()
        {
            string newTitle = "Chicken Parmesan";
            testRecipe.Title = newTitle;
            Assert.Equal(newTitle, testRecipe.Title);
        }

        [Fact]
        public void CanChangeIngredients()
        {
            string newIngredients = "Chicken, Sauce, Parmesan";
            testRecipe.Ingredients = newIngredients;
            Assert.Equal(newIngredients, testRecipe.Ingredients);
        }

        [Fact]
        public void CanChangeInstructions()
        {
            string newInstructions = "Cook chicken then melt cheese";
            testRecipe.Instructions = newInstructions;
            Assert.Equal(newInstructions, testRecipe.Instructions);
        }

        [Fact]
        public void CanChangeDescription()
        {
            string newDescription = "Delicious chicken with sauce and parmesan";
            testRecipe.Description = newDescription;
            Assert.Equal(newDescription, testRecipe.Description);
        }

        [Fact]
        public void CanChangeSource()
        {
            string newSource = "Original Family Recipe";
            testRecipe.Source = newSource;
            Assert.Equal(newSource, testRecipe.Source);
        }

        [Fact]
        public void CanChangeRating()
        {
            int newRating = 4;
            testRecipe.Rating = newRating;
            Assert.Equal(newRating, testRecipe.Rating);
        }

        [Fact]
        public void CanChangePrepTime()
        {
            string newPrepTime = "45 minutes";
            testRecipe.PrepTime = newPrepTime;
            Assert.Equal(newPrepTime, testRecipe.PrepTime);
        }
    }
}
