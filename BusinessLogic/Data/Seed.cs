using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Data
{
    public class Seed
    {
        internal readonly static Seed Instance = new Seed();

        private Seed() { }

        internal void SeedData(ModelBuilder modelBuilder)
        {
            var items = RecipeReader.FromJsonFile();

            modelBuilder.Entity<Recipe>().HasData(items);
        }
    }
}
