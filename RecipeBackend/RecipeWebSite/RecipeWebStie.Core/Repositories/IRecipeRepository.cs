using RecipeWebStie.Core.Models;

namespace RecipeWebStie.Core.Repositories
{
    public interface IRecipeRepository
    {
        Task<List<Recipe>> GetRecipeListAsync();
        Task<Recipe> GetRecipeByIdAsync(int id);
        Task<Recipe> UpdateRecipe(Recipe recipe);
        Task<List<Recipe>> GetRecipesByCategoryAsync(int categoryId);
    }
}
