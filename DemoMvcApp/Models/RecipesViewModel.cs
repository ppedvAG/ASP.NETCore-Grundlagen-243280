using BusinessLogic.Models.Enums;
using System.Text.Json.Serialization;

namespace DemoMvcApp.Models
{
    public class RecipesViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? ImageUrl { get; set; }

        public string[] Ingredients { get; set; }

        public string[] Instructions { get; set; }

        public int PrepTimeMinutes { get; set; }

        public int CookTimeMinutes { get; set; }

        public Difficulty Difficulty { get; set; }

        public string Cuisine { get; set; }

        public string MealType { get; set; }

        public float Rating { get; set; }
    }
}
