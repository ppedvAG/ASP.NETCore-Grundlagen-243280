using BusinessLogic.Contracts;
using BusinessLogic.Data;
using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    /// <summary>
    /// Service welcher den Datenbankzugriff abbilden soll, vgl. <see href="https://de.wikipedia.org/wiki/Repository_(Entwurfsmuster)"/> Repository-Pattern.</see>
    /// Dieser Service bildet CRUD Operationen auf die Rezepte ab.
    /// </summary>
    public class RecipeService
    {
        private readonly DemoDbContext _context;

        public RecipeService(DemoDbContext context)
        {
            _context = context;
        }

        public async Task<List<Recipe>> GetRecipes()
        {
            return await _context.Recipes.ToListAsync();
        }

        public Task<Recipe?> GetRecipe(int id)
        {
            return _context.Recipes.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRecipe(Recipe recipe)
        {
            _context.Update(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteRecipe(int id)
        {
            var recipe = await GetRecipe(id);
            if (recipe != null)
            {
                _context.Recipes.Remove(recipe);
                await _context.SaveChangesAsync();

                return true;
            }
            return false;
        }
    }
}
