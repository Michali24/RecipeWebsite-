using Microsoft.EntityFrameworkCore;
using RecipeWebStie.Core.Models;
using RecipeWebStie.Core.Repositories;
using RecipeWebStie.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RecipeWebStie.Data.Repositories.UserRepository;

namespace RecipeWebStie.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _datacontext;

        public UserRepository(DataContext context)
        {
            _datacontext = context;
        }

        public List<User> GetUsersList()
        {
            return _datacontext.Users.ToList();
        }
        public User GetUserById(int id)
        {
            return _datacontext.Users.FirstOrDefault(u => u.Id == id);
        }

        public void AddUser(User user)
        {
            _datacontext.Users.Add(user);
            _datacontext.SaveChanges();
        }

        // פונקציה סינכרונית שמחזירה משתמש לפי שם המשתמש
        public async Task<User> GetUserByName(string username)
        {
            return await _datacontext.Users.FirstOrDefaultAsync(u=>u.UserName.Equals(username));
        }
    }
}
