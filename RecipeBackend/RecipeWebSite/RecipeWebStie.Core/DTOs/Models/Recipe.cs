using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeWebStie.Core.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string RecipeAuthor { get; set; }
        public string DifficultyLevel { get; set; }
        [MaxLength]
        public string Description { get; set; }
        [MaxLength]
        public string PreparationInstructions { get; set; }
        public int NumOfIngredients { get; set; }
        public int NumOfClicks { get; set; }
        public double PreparationTime { get; set; }
        public int NumberOfRatings { get; set; }
        public double AverageRating { get; set; }
        public double FinalScore { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<Rating> Ratings { get; set; } = new List<Rating>();
    }
}
