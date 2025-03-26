using System.ComponentModel.DataAnnotations;

namespace RecipeWebStie.Core.DTOs
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string RecipeAuthor { get; set; }
        public string DifficultyLevel { get; set; }
        public string Description { get; set; }
        [MaxLength]
        public string PreparationInstructions { get; set; }
        public double PreparationTime { get; set; }
        public double AverageRating { get; set; }
        public int NumOfIngredients { get; set; }
        public int NumOfClicks { get; set; }
        public int NumberOfRatings { get; set; }
    }
}
