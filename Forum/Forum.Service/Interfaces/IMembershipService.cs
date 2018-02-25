using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Forum.Domain.Entities;
using Forum.Domain.Models;

namespace Forum.Service.Interfaces
{
    public interface IMembershipService
    {
        User CreateUser(User user);

        User GetUserById(int id);
        List<User> GetAllUsers();
        User GetUserByEmail(string email);
        bool ChangePassword(string username, string oldPassword, string newPassword);
        UserContext ValidateUser(string username, string password);
        bool UserExist(string email);
        bool IsUsersExist();



    }
}
