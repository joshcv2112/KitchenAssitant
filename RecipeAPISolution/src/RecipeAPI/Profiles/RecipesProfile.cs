using AutoMapper;
using RecipeAPI.Dtos;
using RecipeAPI.Models;

namespace RecipeAPI.Profiles
{
    public class RecipesProfile : Profile
    {
        public RecipesProfile()
        {
            CreateMap<Recipe, RecipeReadDto>();
        }
    }
}