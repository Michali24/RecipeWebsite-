using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeWebStie.Core.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string IngredientName {  get; set; }
        public string Quantity { get; set; }
        public int RecipeId { get; set; }
        [ForeignKey("RecipeId")]
        public virtual Recipe? Recipe { get; set; }
    }
}
