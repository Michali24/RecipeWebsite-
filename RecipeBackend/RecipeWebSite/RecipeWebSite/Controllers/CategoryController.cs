using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeWebSite.Service;
using RecipeWebStie.Core.DTOs;
using RecipeWebStie.Core.Models;
using RecipeWebStie.Core.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipeWebSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;

        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<List<CategoryDto>> GetAllCategories()
        {
            var categories = _categoryService.GetAllCategories();
            var categoryDtos = _mapper.Map<List<CategoryDto>>(categories);
            return Ok(categoryDtos);
        }

        //[HttpGet("{id}")]
        //[AllowAnonymous]
        //public async Task<IActionResult> GetCategoryById(int id)
        //{
        //    var category = await _categoryService.GetCategoryByIdAsync(id);

        //    if (category == null)
        //    {
        //        return NotFound("Category not found.");
        //    }

        //    return Ok(category);
        //}

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<CategoryDto>> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);

            if (category == null)
            {
                return NotFound("Category not found.");
            }
            var categoryDtos = _mapper.Map<CategoryDto>(category);
            return Ok(categoryDtos);
        }
    }
}
