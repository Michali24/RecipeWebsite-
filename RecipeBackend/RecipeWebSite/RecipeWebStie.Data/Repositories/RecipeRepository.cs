using Microsoft.EntityFrameworkCore;
using RecipeWebStie.Core.Models;
using RecipeWebStie.Core.Repositories;

namespace RecipeWebStie.Data.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly DataContext _datacontext;

        public RecipeRepository(DataContext context)
        {
            _datacontext = context;
        }
        public async Task<List<Recipe>> GetRecipeListAsync()
        {
            return await _datacontext.Recipes.ToListAsync();
        }

        public async Task<Recipe> GetRecipeByIdAsync(int id)
        {
            return await _datacontext.Recipes.FirstAsync(r => r.Id == id);
        }

        public async Task<Recipe> UpdateRecipe(Recipe recipe)
        {
            _datacontext.Entry(recipe).State = EntityState.Modified;
            await _datacontext.SaveChangesAsync();
            return recipe;
        }

        public async Task<List<Recipe>> GetRecipesByCategoryAsync(int categoryId)
        {
            return await _datacontext.Recipes
                .Where(r => r.CategoryId == categoryId)
                .ToListAsync();
        }
    }
}
