using AutoMapper;
using RecipeWebStie.Core.DTOs;
using RecipeWebStie.Core.Models;
using RecipeWebStie.Core.Repositories;
using RecipeWebStie.Core.Service;

namespace RecipeWebSite.Service
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;

        public RecipeService(IRecipeRepository recipeRepository, IRatingRepository ratingRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }
        public async Task<List<Recipe>> GetRecipeListAsync()
        {
            return await _recipeRepository.GetRecipeListAsync();
        }

        public async Task<double> CalculateAverageRating(int recipeId)
        {
            var ratings = await _ratingRepository.GetRatingsByRecipeId(recipeId);
            if (!ratings.Any())
            {
                return 0;
            }

            double average = ratings.Average(r => r.RatingValue);

            // Update the recipe with the new average and save the data
            var recipe = await _recipeRepository.GetRecipeByIdAsync(recipeId);
            if (recipe != null)
            {
                recipe.AverageRating = average;
                recipe.NumberOfRatings = ratings.Count();
                await _recipeRepository.UpdateRecipe(recipe);
            }
            return average;
        }

        //Updates a recipe with its new average rating and saves the changes
        public async Task<Recipe> UpdateRecipe(Recipe recipe)
        {
            Recipe recipe1 = await _recipeRepository.GetRecipeByIdAsync(recipe.Id);
            if (recipe1 is not null)
            {
                recipe1.AverageRating = await CalculateAverageRating(recipe.Id);
                recipe1 = await _recipeRepository.UpdateRecipe(recipe1);

            }
            return recipe1;
        }

        public async Task<Recipe> GetRecipeByIdAsync(int id)
        {
            Recipe recipe = await _recipeRepository.GetRecipeByIdAsync(id);

            // If we found the requested recipe, we update the counter
            if (recipe is not null)
            {
                recipe.NumOfClicks++;
                recipe = await _recipeRepository.UpdateRecipe(recipe);
            }
            return recipe;
        }

        public async Task<List<RecipeDto>> GetRecipesByCategoryAsync(int categoryId)
        {
            var recipes = await _recipeRepository.GetRecipesByCategoryAsync(categoryId);
            return _mapper.Map<List<RecipeDto>>(recipes);
        }

        //Returns the top 10 recipes based on a calculated final score.
        public async Task<List<RecipeDto>> GetTop10Recipes()
        {
            var recipes = await _recipeRepository.GetRecipeListAsync();
            if (recipes == null || !recipes.Any())
            {
                return new List<RecipeDto>();
            }
            int maxViews = recipes.Max(r => r.NumOfClicks);
            double siteAverageRating = await _ratingRepository.GetSiteAverageRating();
            int m = 10;

            foreach (var recipe in recipes)
            {
                recipe.FinalScore = CalculateFinalScore(recipe, maxViews, siteAverageRating, m);
            }

            var topRecipes = recipes.OrderByDescending(r => r.FinalScore).Take(10).ToList();

            return topRecipes.Select(r => new RecipeDto
            {
                Id = r.Id,
                Title = r.Title,
                RecipeAuthor = r.RecipeAuthor,
                DifficultyLevel = r.DifficultyLevel,
                Description = r.Description,
                PreparationInstructions = r.PreparationInstructions,
                PreparationTime = r.PreparationTime,
                AverageRating = r.AverageRating,
                NumOfIngredients = r.NumOfIngredients,
                NumOfClicks = r.NumOfClicks,
                NumberOfRatings = r.NumberOfRatings
            }).ToList();
        }

        //Calculates the final score of a recipe based on views, rating, and difficulty.
        private double CalculateFinalScore(Recipe recipe, int maxViews, double siteAverageRating, int m)
        {
            double viewsNorm = maxViews > 0 ? (double)recipe.NumOfClicks / maxViews : 0;
            double weightedRating = ((recipe.AverageRating * recipe.NumberOfRatings) + (siteAverageRating * m)) / (recipe.NumberOfRatings + m);
            double ratingNorm = weightedRating / 5.0;
            double difficultyNorm = (3 - int.Parse(recipe.DifficultyLevel)) / 2.0;
            return (viewsNorm * 0.3) + (ratingNorm * 0.5) + (difficultyNorm * 0.2);
        }
    }
}
