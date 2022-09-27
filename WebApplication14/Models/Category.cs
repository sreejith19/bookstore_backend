using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication14.Models
{
    public class Category
    {
        public int catId;
        public string catName;
        public string description;
        public string catImage;
        public int status;
        public string position;
        public DateTime createdAt;
        public Category(int id, string name, string desc, string img, int s, string pos, DateTime date)
        {
            this.catId = id;
            this.catName = name;
            this.description = desc;
            this.catImage = img;
            this.status = s;
            this.position = pos;
            this.createdAt = date;
        }
    }
}