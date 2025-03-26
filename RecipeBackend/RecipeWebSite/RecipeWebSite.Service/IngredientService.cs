using RecipeWebStie.Core.Models;
using RecipeWebStie.Core.Repositories;
using RecipeWebStie.Core.Service;

namespace RecipeWebSite.Service
{
    public class IngredientService:IIngredientService
    {
        private readonly IIngredientRepository _ingredientrepository;

        public IngredientService(IIngredientRepository repository)
        {
            _ingredientrepository = repository;
        }

        public List<Ingredient> GetAllIngredients()
        {
            return _ingredientrepository.GetIngredientList();
        }

        public Ingredient GetIngredientById(int id)
        {
            return _ingredientrepository.GetIngredientById(id);
        }

        public List<Ingredient> GetIngredientsByRecipe(int recipeId)
        {
            return _ingredientrepository.GetIngredientsByRecipe(recipeId);
        }
    }
}
