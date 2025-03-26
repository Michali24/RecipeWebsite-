using Microsoft.EntityFrameworkCore;
using RecipeWebStie.Core.Models;
using RecipeWebStie.Core.Repositories;

namespace RecipeWebStie.Data.Repositories
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly DataContext _datacontext;

        public CategoryRepository(DataContext datacontext)
        {
            _datacontext = datacontext;
        }

        public List<Category> GetCategoriesList()
        {
            return _datacontext.Categories.ToList();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _datacontext.Categories
                .FirstOrDefaultAsync(c => c.Id == id);  // מחזיר את הקטגוריה לפי ה-ID
        }
    }
}

