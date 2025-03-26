using RecipeWebStie.Core.Models;

namespace RecipeWebStie.Core.Service
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories();
        Task<Category> GetCategoryByIdAsync(int id);
    }
}
