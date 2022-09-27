using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication14.Models
{
    public class Credentials
    {
        public string userName{ get; set; }
        public string password { get; set; }

        public Credentials(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }
    }
}