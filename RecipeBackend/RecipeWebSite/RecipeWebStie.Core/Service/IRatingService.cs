using RecipeWebStie.Core.Models;

namespace RecipeWebStie.Core.Service
{
    public interface IRatingService
    {
        public List<Rating>GetAllRatings();
        Rating GetRatingById(int id);
        Task<Rating> AddRatingAsync(Rating rating);
        void UpdateRating(int id, Rating rating);
        Task<double> GetSiteAverageRating();
    }
}
