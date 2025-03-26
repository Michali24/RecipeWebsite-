using RecipeWebStie.Core.DTOs;
using RecipeWebStie.Core.Models;

namespace RecipeWebStie.Core.Service
{
    public interface IRecipeService
    {
        Task<List<Recipe>> GetRecipeListAsync();
        Task<double> CalculateAverageRating(int recipeId);
        Task<Recipe> GetRecipeByIdAsync(int id);        
        Task<Recipe> UpdateRecipe(Recipe recipe);
        Task<List<RecipeDto>> GetRecipesByCategoryAsync(int categoryId);
        Task<List<RecipeDto>> GetTop10Recipes();
    }
}
