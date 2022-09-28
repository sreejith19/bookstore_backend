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

        
        public Order(int orderId, int userId, int bookId, DateTime orderTime,double basePrice,double sellingPrice,int status, string[] coupons)
        {
            this.orderId = orderId;
            this.userId = userId;
            this.bookId = bookId;
            this.orderTime = orderTime;
            this.basePrice = basePrice;
            this.status = status;
            this.sellingPrice = sellingPrice;
            this.coupons = coupons;
        }
    }
}