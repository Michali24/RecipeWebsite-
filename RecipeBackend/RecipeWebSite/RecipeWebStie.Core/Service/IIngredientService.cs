using RecipeWebStie.Core.Models;

namespace RecipeWebStie.Core.Service
{
    public interface IIngredientService
    {
        public List<Ingredient> GetAllIngredients();
        Ingredient GetIngredientById(int id);
        List<Ingredient> GetIngredientsByRecipe(int recipeId);
    }
}
