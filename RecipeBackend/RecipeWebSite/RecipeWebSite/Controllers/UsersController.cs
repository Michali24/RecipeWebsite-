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
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IMapper _mapper;


        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;

        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<List<UserDto>> Get()
        {
            var list = _userService.GetAllUsers();
            var listDto = _mapper.Map<List<UserDto>>(list);
            return Ok(listDto);
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            var userDto = _mapper.Map<User>(user);
            return Ok(userDto);
        }

        [HttpGet("GetUserByName")]
        [AllowAnonymous]
        public ActionResult<User> Get(string userName)
        {
            var user = _userService.GetUserByName(userName);
            if (user == null)
            {
                return NotFound();
            }
            var userDto = _mapper.Map<User>(user);
            return Ok(userDto);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult SignUp([FromBody] UserPostModel userPostModel)
        {
            var user = _mapper.Map<User>(userPostModel);
            _userService.AddUser(user);
            return Ok();
        }
    }
}
