using RecipeWebStie.Core.Models;
using RecipeWebStie.Core.Repositories;
using RecipeWebStie.Core.Service;

namespace RecipeWebSite.Service;
public class RatingService : IRatingService
{
    private readonly IRatingRepository _ratingRepository;

    public RatingService(IRatingRepository ratingRepository)
    {
        _ratingRepository = ratingRepository;
    }

    public List<Rating> GetAllRatings()
    {
        return _ratingRepository.GetRatingsList();
    }

    public Rating GetRatingById(int id)
    {
        return _ratingRepository.GetRatingById(id);
    }

    public async Task<Rating> AddRatingAsync(Rating rating)
    {
        await _ratingRepository.AddRatingAsync(rating);
        return rating;
    }

    public void UpdateRating(int id, Rating rating)
    {
        _ratingRepository.UpdateRating(id, rating);
    }

    // Returns the average rating of all recipes on the website.
    // Used in the algorithm that calculates the final score of a recipe.
    public async Task<double> GetSiteAverageRating()
    {
        return await _ratingRepository.GetSiteAverageRating();
    }
}
