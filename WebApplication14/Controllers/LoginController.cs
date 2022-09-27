using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication14.Models;

namespace WebApplication14.Controllers
{
    public class LoginController : ApiController
    {
        private ILoginRepository repository;

        public LoginController()
        {
            repository = new LoginImplementation();
        }
        [System.Web.Http.ActionName("Admin")]
        [System.Web.Http.HttpPost]
        public Boolean AdminLogin([FromBody] Credentials credentials)
        {
            Debug.WriteLine("new admin login");
            var status = repository.Validate(credentials, "admin");
            return status;
        }
        [System.Web.Http.ActionName("User")]
        [System.Web.Http.HttpPost]
        public Boolean UserLogin([FromBody] Credentials credentials)
        {
            Debug.WriteLine("new user login");
            var status = repository.Validate(credentials, "customer");
            return status;
        }
        [System.Web.Http.ActionName("Edit")]
        [System.Web.Http.HttpPost]
        public int Edit([FromBody] List<Credentials> credentials)
        {
            Credentials credential = credentials[0];
            string new_password = credentials[1].password;
            Debug.WriteLine("user password change");
            var status = repository.ChangePassword(credential, new_password);
            return status;
        }
        [System.Web.Http.ActionName("Add")]
        [System.Web.Http.HttpPost]
        public int Add([FromBody] Credentials credentials)
        {
            Debug.WriteLine("new user added");
            var status = repository.AddUser(credentials);
            return status;
        }
        [System.Web.Http.ActionName("UserExists")]
        [System.Web.Http.HttpPost]
        public bool UserExists([FromBody] string name)
        {
            var status = repository.UserExists(name);
            return status;
        }
        [System.Web.Http.ActionName("Delete")]
        [System.Web.Http.HttpPost]
        public int DeleteUser([FromBody] Credentials credentials)
        {
            var status = repository.DeleteUser(credentials);
            return status;
        }

    }
}
