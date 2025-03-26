using RecipeWebStie.Core.Models;
using RecipeWebStie.Core.Repositories;
using RecipeWebStie.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RecipeWebSite.Service.UserService;

namespace RecipeWebSite.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetUsersList();
        }
        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }
        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }
        public async Task<User> GetUserByName(string username)
        {
            return await _userRepository.GetUserByName(username);
        }
    }

}
