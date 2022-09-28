using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication14.Models
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetUserById(int id);
        User GetUserByUserName(string username);
        User GetUserByEMail(string email);
        int AddUser(User user);
        int EditUser(User user);
        int DeleteUser(User user);
        int GetUserIdByUserName(string username);
        int ChangeUserName(string oldName,string newName);
    }
}
