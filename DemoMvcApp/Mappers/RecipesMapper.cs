using BusinessLogic.Models;
using DemoMvcApp.Models;
using System.Text.RegularExpressions;

namespace DemoMvcApp.Mappers
{
    public static class RecipesMapper
    {
        public static RecipesViewModel ToViewModel(this Recipe recipe)
        {
            var path = Regex.Replace(recipe.Name, @"\W+", string.Empty);
            return new RecipesViewModel
            {
                Id = recipe.Id,
                Path = path,
                Name = recipe.Name,
                ImageUrl = recipe.ImageUrl,
                Ingredients = recipe.Ingredients,
                Instructions = recipe.Instructions,
                CookTimeMinutes = recipe.CookTimeMinutes,
                PrepTimeMinutes = recipe.PrepTimeMinutes,
                Cuisine = recipe.Cuisine,
                Difficulty = recipe.Difficulty,
                MealType = recipe.MealType.FirstOrDefault() ?? string.Empty,
                Rating = recipe.Rating,
            };
        }

        public static Recipe ToDomainModel(this RecipesViewModel recipe)
        {
            return new Recipe
            {
                Id = recipe.Id,
                Name = recipe.Name,
                ImageUrl = recipe.ImageUrl,
                Ingredients = recipe.Ingredients,
                Instructions = recipe.Instructions,
                CookTimeMinutes = recipe.CookTimeMinutes,
                PrepTimeMinutes = recipe.PrepTimeMinutes,
                Cuisine = recipe.Cuisine,
                Difficulty = recipe.Difficulty,
                MealType = [recipe.MealType],
                Rating = recipe.Rating,
            };
        }
    }
}
