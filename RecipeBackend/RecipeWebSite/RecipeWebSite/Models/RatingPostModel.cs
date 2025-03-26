namespace RecipeWebSite.Models
{
    public class RatingPostModel
    {
        public int RatingValue { get; set; }
        public int RecipeId { get; set; }
        public int UserId { get; set; }
    }
}
