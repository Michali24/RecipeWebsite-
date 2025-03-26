using RecipeWebStie.Core.Models;

namespace RecipeWebStie.Core.Repositories
{
    public interface IIngredientRepository
    {
        public List<Ingredient> GetIngredientList();
        Ingredient GetIngredientById(int id);
        List<Ingredient> GetIngredientsByRecipe(int recipeId);
    }
}
