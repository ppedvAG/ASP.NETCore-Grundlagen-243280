using BusinessLogic.Models;
using DemoMvcApp.Models;

namespace DemoMvcApp.Mappers
{
    public static class RecipesMapper
    {
        public static RecipesViewModel ToViewModel(this Recipe recipe)
        {
            return new RecipesViewModel
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
                MealType = recipe.MealType.FirstOrDefault() ?? string.Empty,
                Rating = recipe.Rating,
            };
        }

        public static Recipe ToDomainModel(this CreateRecipeViewModel recipe)
        {
            return new Recipe
            {
                Id = recipe.Id,
                Name = recipe.Name,
                ImageUrl = recipe.ImageUrl ?? string.Empty,
                Ingredients = recipe.Ingredients?.Split(Environment.NewLine) ?? [],
                Instructions = recipe.Instructions?.Split(Environment.NewLine) ?? [],
                CookTimeMinutes = recipe.CookTimeMinutes,
                PrepTimeMinutes = recipe.PrepTimeMinutes,
                Cuisine = recipe.Cuisine,
                Difficulty = recipe.Difficulty,
                MealType = [recipe.MealType],
                Rating = recipe.Rating,
                CaloriesPerServing = recipe.CaloriesPerServing ?? 0,
                Tags = recipe.Tags?.Split(",") ?? [],
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
