using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication14.Models
{
    public class WishListEntry
    {
        public int userId { get; set; }
        public int bookId { get; set; }
        public WishListEntry(int userId,int bookId)
        {
            this.userId = userId;
            this.bookId = bookId;
        }
    }
}