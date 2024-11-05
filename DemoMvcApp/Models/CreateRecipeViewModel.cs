using BusinessLogic.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DemoMvcApp.Models
{
    public class CreateRecipeViewModel : RecipesViewModel
    {
        [Required]
        public string Name { get; set; }

        [Display(Name = "Image Url")]
        public string? ImageUrl { get; set; }

        public string? Ingredients { get; set; }

        public string? Instructions { get; set; }

        [Range(0, 120, ErrorMessage = "Cook time must be between 0 and 120 minutes")]
        public int PrepTimeMinutes { get; set; }

        [Range(0, 120, ErrorMessage = "Cook time must be between 0 and 120 minutes")]
        public int CookTimeMinutes { get; set; }

        [Display(Name = "Difficulty")]
        public Difficulty Difficulty { get; set; }

        public string Cuisine { get; set; }

        [Display(Name = "Meal Type")]
        public string MealType { get; set; }

        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5")]
        public float Rating { get; set; }

        public int? CaloriesPerServing { get; set; }

        public string? Tags { get; set; }
    }
}
