using System.ComponentModel.DataAnnotations;

namespace RecipeWebStie.Core.Models
{
    public class Category
    {
        public int Id { get; set; } 
        public string CategoryName { get; set; }
        [MaxLength]
        public string Description { get; set; }
        public List<Recipe> Recipes {  get; set; }=new List<Recipe>(); 
    }
}
