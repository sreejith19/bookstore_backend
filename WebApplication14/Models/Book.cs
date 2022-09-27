using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication14.Models
{
    public class Book
    {
        public int bookId { get; set; }
        public int catId{ get; set; }
        public string title { get; set; }
        public string isbn { get; set; }
        public int year { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public string position { get; set; }
        public int status { get; set; }
        public string image { get; set; }
        public string author { get; set; }

        public Book(int bookId, int catId, string title, string isbn, int year, double price, string description, string position, int status, string image,string author)
        {
            this.bookId = bookId;
            this.catId=catId;
            this.title=title;
            this.isbn=isbn;
            this.year=year;
            this.price=price;
            this.description=description;
            this.position=position;
            this.status=status;
            this.image=image;
            this.author=author;
        }

    }
}