using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dormitories.Models;

namespace Dormitories.Services
{
    public interface IUserService
    {
        List<User> GetUsers();
        User GetUserByUserName(string username);
        User GetUserById(int id);
        bool InsertUser(User user);
    }
}