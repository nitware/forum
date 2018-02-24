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
        Person CreateUser(Person user);

        Person GetUserById(int id);
        List<Person> GetAllUsers();
        Person GetUserByEmail(string email);
        bool ChangePassword(string username, string oldPassword, string newPassword);
        PersonContext ValidateUser(string username, string password);
        bool UserExist(string email);
        

    }
}
