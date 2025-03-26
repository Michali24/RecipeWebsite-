using RecipeWebStie.Core.Models;

namespace RecipeWebStie.Core.Service
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetUserById(int id);
        void AddUser(User user);
        Task<User> GetUserByName(string username);
    }
}
