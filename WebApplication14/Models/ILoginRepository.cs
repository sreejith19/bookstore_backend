using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication14.Models
{
    public interface ILoginRepository
    {
        Boolean Validate(Credentials credentials,string type);
        int GetIdFromUser(Credentials credentials);
        int ChangePassword(Credentials credentials, string new_password);
        int AddUser(Credentials credentials);
        bool UserExists(string name);
        int DeleteUser(Credentials credentials);
    }
}
