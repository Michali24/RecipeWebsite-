using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeWebSite.Models;
using RecipeWebStie.Core.DTOs;
using RecipeWebStie.Core.Models;
using RecipeWebStie.Core.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipeWebSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;
        private readonly IRecipeService _recipeService;
        private readonly IMapper _mapper;

        public RatingController(IRatingService ratingService, IRecipeService recipeService, IMapper mapper)
        {
            _ratingService = ratingService;
            _recipeService = recipeService;
            _mapper = mapper;
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<List<RatingDto>> Get()
        {
            var ratings = _ratingService.GetAllRatings();
            var listRatingsDto = _mapper.Map<List<RatingDto>>(ratings);
            return Ok(listRatingsDto);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<RatingDto> GetRating(int id)
        {
            var rating = _ratingService.GetRatingById(id);
            if (rating == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<RatingDto>(rating));
        }

        //[HttpPost("createRating")]
        //public async Task<IActionResult> CreateRating([FromBody] RatingPostModel ratingPostModel)
        //{
        //    if (ratingPostModel == null)
        //    {
        //        return BadRequest("Invalid rating data.");
        //    }

        //    var rating = _mapper.Map<Rating>(ratingPostModel);

        //    await _ratingService.AddRatingAsync(rating); // הוספת הדירוג ושמירתו במסד הנתונים

        //    double updatedAverage = await _recipeService.CalculateAverageRating(rating.RecipeId);

        //    return CreatedAtAction(nameof(GetRating), new { id = rating.Id }, _mapper.Map<RatingDto>(rating));
        //}

        [HttpPost("createRating")]
        public async Task<ActionResult<RatingDto>> CreateRating([FromBody] RatingPostModel ratingPostModel)
        {
            if (ratingPostModel == null)
            {
                return BadRequest("Invalid rating data.");
            }

            var rating = _mapper.Map<Rating>(ratingPostModel);

            await _ratingService.AddRatingAsync(rating); // הוספת הדירוג ושמירתו במסד הנתונים

            double updatedAverage = await _recipeService.CalculateAverageRating(rating.RecipeId);

            return CreatedAtAction(nameof(GetRating), new { id = rating.Id }, _mapper.Map<RatingDto>(rating));
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public IActionResult UpdateRating(int id, [FromBody] RatingPutModel ratingPutModel)
        {
            var rating = _ratingService.GetRatingById(id);
            if (rating == null)
            {
                return NotFound();
            }

            _mapper.Map(ratingPutModel, rating);
            _ratingService.UpdateRating(id, rating);
            return NoContent();
        }
    }
}
