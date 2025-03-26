using RecipeWebStie.Core.Models;
using RecipeWebStie.Core.Repositories;

namespace RecipeWebStie.Data.Repositories
{
    public class IngredientRepository:IIngredientRepository
    {
        private readonly DataContext _dataContext;

        public IngredientRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Ingredient> GetIngredientList()
        {
            return _dataContext.Ingredients.ToList();
        }

        public Ingredient GetIngredientById(int id)
        {
            return _dataContext.Ingredients.FirstOrDefault(i => i.Id == id);
        }

        public List<Ingredient> GetIngredientsByRecipe(int recipeId)
        {
            return _dataContext.Ingredients.Where(i => i.RecipeId == recipeId).ToList();
        }
    }
}
