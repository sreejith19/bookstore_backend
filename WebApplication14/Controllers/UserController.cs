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
    public class UserController : ApiController
    {
        private IUserRepository repository;
        public UserController()
        {
            repository = new UserImplementation();
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.GetAll();
            return Ok(data);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult Get(int id)
        {
            var data = repository.GetUserById(id);
            return Ok(data);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult Get(string value)
        {
            var data = repository.GetUserByUserName(value);
            return Ok(data);
        }
        [System.Web.Http.ActionName("Email")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetUser(string value)
        {
            var data = repository.GetUserByEMail(value);
            return Ok(data);
        }

        [System.Web.Http.ActionName("UserId")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetUserId(string value)
        {
            int data = repository.GetUserIdByUserName(value);
            return Ok(data);
        }

        [System.Web.Http.ActionName("Add")]
        [System.Web.Http.HttpPost]
        public int Add([FromBody] User user)
        {
            Debug.WriteLine("new add");
            int data = repository.AddUser(user);
            return data;
        }
        [System.Web.Http.ActionName("Edit")]
        [System.Web.Http.HttpPost]
        public int Edit([FromBody] User user)
        {
            Debug.WriteLine("new edit");
            int data = repository.EditUser(user);
            return data;
        }
        [System.Web.Http.ActionName("Delete")]
        [System.Web.Http.HttpPost]
        public int Delete([FromBody] User user)
        {
            Debug.WriteLine("new delete");
            var data = repository.DeleteUser(user);
            return data;
        }
        [System.Web.Http.ActionName("ChangeUserName")]
        [System.Web.Http.HttpPost]
        public int ChangeUserName([FromBody] string data)
        {
            Debug.WriteLine("new username");

            string[] names = data.Split(',');
            var resp = repository.ChangeUserName(names[0], names[1]);
            return resp;
        }

    }
}
