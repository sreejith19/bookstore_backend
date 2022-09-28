using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication14.Models
{
    public class Coupon
    {
        public int couponId { get; set; }
        public string code{ get; set; }
        public double discount { get; set; }
        public int status { get; set; }

        public Coupon(int couponId, string code, double discount, int status)
        {
            this.code = code;
            this.discount = discount;
            this.couponId = couponId;
            this.status = status;
        }
    }
}