using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication14.Models
{
    public class User
    {
        public string username { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public DateTime joinedAt { get; set; }

        public User(string username,string email,string phone,string address,DateTime joinedAt) 
        {
            this.username = username;
            this.email = email;
            this.phone = phone;
            this.address = address;
            this.joinedAt = joinedAt;
        }
    }
}