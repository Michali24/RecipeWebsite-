using RecipeWebStie.Core.Models;

namespace RecipeWebStie.Core.Repositories
{
    public interface ICategoryRepository
    {
        public List<Category> GetCategoriesList();
        Task<Category> GetCategoryByIdAsync(int id);
    }
}
