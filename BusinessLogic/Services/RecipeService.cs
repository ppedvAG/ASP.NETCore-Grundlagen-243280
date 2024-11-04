using BusinessLogic.Contracts;
using BusinessLogic.Data;
using BusinessLogic.Models;

namespace BusinessLogic.Services
{
    /// <summary>
    /// Service welcher den Datenbankzugriff abbilden soll, vgl. <see href="https://de.wikipedia.org/wiki/Repository_(Entwurfsmuster)"/> Repository-Pattern.</see>
    /// Dieser Service bildet CRUD Operationen auf die Rezepte ab.
    /// </summary>
    public class RecipeService : IRecipeService
    {
        private readonly List<Recipe> _recipes = RecipeReader.FromJsonFile() ?? new List<Recipe>();

        public List<Recipe> GetRecipes()
        {
            return _recipes;
        }

        public Recipe GetRecipe(int id)
        {
            return _recipes.FirstOrDefault(r => r.Id == id);
        }

        public void AddRecipe(Recipe recipe)
        {
            _recipes.Add(recipe);
        }

        public void UpdateRecipe(Recipe recipe)
        {
            var index = _recipes.FindIndex(r => r.Id == recipe.Id);
            if (index >= 0)
            {
                _recipes[index] = recipe;
            }
        }

        public bool DeleteRecipe(int id)
        {
            var index = _recipes.FindIndex(r => r.Id == id);
            if (index >= 0)
            {
                _recipes.RemoveAt(index);
                return true;
            }
            return false;
        }
    }
}
