using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeWebSite.Models;
using RecipeWebStie.Core.DTOs;
using RecipeWebStie.Core.Models;
using RecipeWebStie.Core.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipeWebSite.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class RecipeController : ControllerBase
{
    private readonly IRecipeService _recipeService;
    private readonly IMapper _mapper;

    public RecipeController(IRecipeService recipeService, IMapper mapper)
    {
        _recipeService = recipeService;
        _mapper = mapper;
    }

    [HttpGet(Name = "GetRecipes")]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<RecipeDto>>> GetRecipes()
    {
        var recipes = await _recipeService.GetRecipeListAsync();

        if (recipes == null || !recipes.Any())
        {
            return NoContent();
        }
        var listDtoRecipe = _mapper.Map<List<RecipeDto>>(recipes);
        return Ok(listDtoRecipe);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<RecipeDto>> GetRecipeById(int id)
    {
        Recipe recipe = await _recipeService.GetRecipeByIdAsync(id);

        if (recipe == null)
        {
            return NotFound();
        }

        RecipeDto recipeDto = _mapper.Map<RecipeDto>(recipe);
        return Ok(recipeDto);
    }

    //[HttpGet("category/{categoryId}")]
    //[AllowAnonymous]
    //public async Task<IActionResult> GetRecipesByCategory(int categoryId)
    //{
    //    var recipes = await _recipeService.GetRecipesByCategoryAsync(categoryId);
    //    var recipeDtos = _mapper.Map<List<RecipeDto>>(recipes);

    //    if (recipes == null || recipes.Count == 0)
    //    {
    //        return NotFound("No recipes found for this category.");
    //    }

    //    return Ok(recipeDtos);
    //}
    [HttpGet("category/{categoryId}")]
    [AllowAnonymous]
    public async Task<ActionResult<RecipeDto>> GetRecipesByCategory(int categoryId)
    {
        var recipes = await _recipeService.GetRecipesByCategoryAsync(categoryId);
        var recipeDtos = _mapper.Map<List<RecipeDto>>(recipes);

        if (recipes == null || recipes.Count == 0)
        {
            return NotFound("No recipes found for this category.");
        }

        return Ok(recipeDtos);
    }

    [HttpPut("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> UpdateRecipe(int id, [FromBody] RecipePutModel recipePutModel)
    {
        var recipe = await _recipeService.GetRecipeByIdAsync(id);
        if (recipe == null)
        {
            return NotFound();
        }
        _mapper.Map(recipePutModel, recipe);
        await _recipeService.UpdateRecipe(recipe);
        return NoContent();
    }

    //[HttpGet("top10")]
    //[AllowAnonymous]
    //public async Task<IActionResult> GetTop10Recipes()
    //{
    //    var topRecipes = await _recipeService.GetTop10Recipes();
    //    return Ok(topRecipes);
    //}
    [HttpGet("top10")]
    [AllowAnonymous]
    public async Task<ActionResult<RecipeDto>> GetTop10Recipes()
    {
        var topRecipes = await _recipeService.GetTop10Recipes();
        return Ok(_mapper.Map<List<RecipeDto>>(topRecipes));
    }
}
