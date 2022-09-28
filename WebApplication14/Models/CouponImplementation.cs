using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc.Ajax;

namespace WebApplication14.Models
{
    public class CouponImplementation:ICouponRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public CouponImplementation()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
        public List<Coupon> GetAll()
        {
            comm.CommandText = "select * from Coupon where status=1;";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            List<Coupon> list = new List<Coupon>();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["couponId"]);
                string code = reader["code"].ToString();
                double discount = Convert.ToDouble(reader["discount"]);
                int s = Convert.ToInt32(reader["status"]);

                list.Add(new Coupon(id, code,discount, s));
            }
            conn.Close();
            return list;
        }
        public Coupon GetCouponById(int id)
        {
            comm.CommandText = "select * from Coupon where couponId=" + id + " ;";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int cId = Convert.ToInt32(reader["couponId"]);
                string code = reader["code"].ToString();
                double discount = Convert.ToDouble(reader["discount"]);
                int s = Convert.ToInt32(reader["status"]);
                conn.Close();
                return new Coupon(cId, code, discount, s);    
            }
            conn.Close();
            return null;
        }
        public Coupon GetCouponByCode(string code)
        {
            comm.CommandText = "select * from Coupon where code='" + code + "' ;";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int cId = Convert.ToInt32(reader["couponId"]);
                string cCode = reader["code"].ToString();
                double discount = Convert.ToDouble(reader["discount"]);
                int s = Convert.ToInt32(reader["status"]);
                conn.Close();
                return new Coupon(cId, cCode, discount, s);
            }
            conn.Close();
            return null;
        }
        public int Add(Coupon coupon)
        {
            comm.CommandText = "insert into Coupon values('" + coupon.code + "'," + coupon.discount + "," + coupon.status + ");";
            comm.Connection = conn;
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            conn.Close();
            int id = GetCouponByCode(coupon.code).couponId;
            return id;
        }
        public int Edit(Coupon coupon)
        {
            comm.CommandText = "update Coupon set code='" + coupon.code + "',discount=" + coupon.discount + ",status=" + coupon.status+ "where couponId=" + coupon.couponId + ";";
            comm.Connection = conn;
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            conn.Close();
            return rows;
        }
        public int Delete(int id)
        {
            comm.CommandText = "delete from Coupon where couponId=" + id;
            comm.Connection = conn;
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            conn.Close();
            return rows;
        }
        public bool Enable(int id)
        {
            Coupon coupon = GetCouponById(id);
            coupon.status = 1;
            int rows=Edit(coupon);
            if (rows > 0)
                return true;
            return false;
        }
        public bool Disable(int id)
        {
            Coupon coupon = GetCouponById(id);
            coupon.status = 0;
            int rows = Edit(coupon);
            if (rows > 0)
                return true;
            return false;
        }
        public static double ApplyCoupons(Order order)
        {
            
            foreach(string coupon in order.coupons){
                Coupon c = new CouponImplementation().GetCouponByCode(coupon);
                if (c is null)
                {
                    continue;
                }
                order.sellingPrice = order.sellingPrice * (100 - c.discount) / 100;
            }
            return order.sellingPrice;
        }
    }
}