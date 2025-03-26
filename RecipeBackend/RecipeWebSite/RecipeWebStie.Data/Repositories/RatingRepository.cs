using Microsoft.EntityFrameworkCore;
using RecipeWebStie.Core.Models;
using RecipeWebStie.Core.Repositories;

namespace RecipeWebStie.Data.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly DataContext _datacontext;

        public RatingRepository(DataContext datacontext)
        {
            _datacontext = datacontext;
        }

        public List<Rating> GetRatingsList()
        {
            return _datacontext.Ratings.ToList();
        }

        public Rating GetRatingById(int id)
        {
            return _datacontext.Ratings.FirstOrDefault(r => r.Id == id);
        }

        public async Task<IEnumerable<Rating>> GetRatingsByRecipeId(int id)
        {
            return await _datacontext.Ratings.Where(r => r.RecipeId == id).ToListAsync();
        }

        public async Task<Rating> AddRatingAsync(Rating rating)
        {
            _datacontext.Ratings.Add(rating);
            await _datacontext.SaveChangesAsync();
            return rating;
        }

        public void UpdateRating(int id, Rating rating)
        {
            var existingRating = _datacontext.Ratings.FirstOrDefault(r => r.Id == id);
            if (existingRating != null)
            {
                existingRating.RatingValue = rating.RatingValue;
                existingRating.RecipeId = rating.RecipeId;
                existingRating.UserId = rating.UserId;
                _datacontext.SaveChanges();
            }
        }

        public async Task<double> GetSiteAverageRating()
        {
            return await _datacontext.Ratings.AverageAsync(r => r.RatingValue);
        }
    }
}
