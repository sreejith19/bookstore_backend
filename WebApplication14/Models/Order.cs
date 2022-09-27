using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication14.Models
{
    public class Order
    {
        public int orderId { get; set; }
        public int userId { get; set; }
        public int bookId { get; set; }
        public DateTime orderTime { get; set; }
        public double basePrice { get; set; }
        public double sellingPrice { get; set; }
        public int status { get; set; }
        public string[] coupons { get; set; }

        private bool applyCoupons()
        {
            //to be implemented
            return true;
        }
        public Order(int userId, int bookId, DateTime orderTime, string[] coupons)
        {
            this.orderId = 0;
            this.userId = userId;
            this.bookId = bookId;
            this.orderTime = orderTime;
            this.basePrice = new BookImplementation().GetBookById(bookId).price;
            this.status = 0;
            this.sellingPrice = basePrice;
            this.coupons = coupons;
            this.applyCoupons();
        }
    }
}