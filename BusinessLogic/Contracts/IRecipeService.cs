using BusinessLogic.Models;

namespace BusinessLogic.Contracts
{
    public interface IRecipeService
    {
        void AddRecipe(Recipe recipe);
        bool DeleteRecipe(int id);
        Recipe GetRecipe(int id);
        List<Recipe> GetRecipes();
        void UpdateRecipe(Recipe recipe);
    }
}