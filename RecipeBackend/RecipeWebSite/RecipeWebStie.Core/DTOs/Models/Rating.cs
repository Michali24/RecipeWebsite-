using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeWebStie.Core.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int RatingValue { get; set; }
        //Weighted rating factoring number of ratings
        public double WeightedRating { get; set; }
        public int RecipeId { get; set; }
        [ForeignKey("RecipeId")]
        public virtual Recipe? Recipe { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
    }
}
