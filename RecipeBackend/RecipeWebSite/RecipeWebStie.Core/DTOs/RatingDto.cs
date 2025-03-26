namespace RecipeWebStie.Core.DTOs
{
    public class RatingDto
    {
        public int Id { get; set; } 
        public int RatingValue { get; set; }
        public int RecipeId { get; set; }
        public int UserId { get; set; }
    }
}
