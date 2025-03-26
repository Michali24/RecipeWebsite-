using RecipeWebStie.Core.Models;

namespace RecipeWebStie.Core.Repositories;
public interface IRatingRepository
{
    public List<Rating> GetRatingsList();
    Rating GetRatingById(int id);
    Task<IEnumerable<Rating>> GetRatingsByRecipeId(int id);
    Task<Rating> AddRatingAsync(Rating rating);
    void UpdateRating(int id, Rating rating);
    Task<double> GetSiteAverageRating();
}
