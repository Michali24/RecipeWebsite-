using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeWebStie.Core.DTOs;
using RecipeWebStie.Core.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipeWebSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;
        private readonly IMapper _mapper;

        public IngredientController(IIngredientService ingredientService, IMapper mapper)
        {
            _ingredientService = ingredientService;
            _mapper = mapper;
        }

        //[HttpGet]
        //[AllowAnonymous]
        //public IActionResult GetAllIngredients()
        //{
        //    var ingredients = _ingredientService.GetAllIngredients();
        //    var ingredientDtos = _mapper.Map<List<IngredientDto>>(ingredients);
        //    return Ok(ingredientDtos);
        //}
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IngredientDto> GetAllIngredients()
        {
            var ingredients = _ingredientService.GetAllIngredients();
            var ingredientDtos = _mapper.Map<List<IngredientDto>>(ingredients);
            return Ok(ingredientDtos);
        }

        //[HttpGet("{id}")]
        //[AllowAnonymous]
        //public IActionResult GetIngredient(int id)
        //{
        //    var ingredient = _ingredientService.GetIngredientById(id);
        //    if (ingredient == null)
        //    {
        //        return NotFound();
        //    }
        //    var ingredientDto = _mapper.Map<IngredientDto>(ingredient);
        //    return Ok(ingredientDto);
        //}

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<IngredientDto> GetIngredient(int id)
        {
            var ingredient = _ingredientService.GetIngredientById(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            var ingredientDto = _mapper.Map<IngredientDto>(ingredient);
            return Ok(ingredientDto);
        }

        //[HttpGet("recipe/{recipeId}")]
        //[AllowAnonymous]
        //public IActionResult GetIngredientsByRecipe(int recipeId)
        //{
        //    var ingredients = _ingredientService.GetIngredientsByRecipe(recipeId);
        //    var ingredientDtos = _mapper.Map<List<IngredientDto>>(ingredients);
        //    return Ok(ingredientDtos);
        //}
        [HttpGet("recipe/{recipeId}")]
        [AllowAnonymous]
        public ActionResult<IngredientDto> GetIngredientsByRecipe(int recipeId)
        {
            var ingredients = _ingredientService.GetIngredientsByRecipe(recipeId);
            var ingredientDtos = _mapper.Map<List<IngredientDto>>(ingredients);
            return Ok(ingredientDtos);
        }
    }
}
