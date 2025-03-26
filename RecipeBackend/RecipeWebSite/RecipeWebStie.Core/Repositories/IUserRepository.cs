using RecipeWebStie.Core.Models;

namespace RecipeWebStie.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByName(string username);
        List<User> GetUsersList();
        User GetUserById(int id);
        void AddUser(User user);
    }
}
