using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq;
using System.Web;

namespace WebApplication14.Models
{
    public class OrderImplementation:IOrderRepository
    {
        SqlConnection conn;
        SqlConnection conn2;
        SqlCommand comm;
        public OrderImplementation()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand(); 
            conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);

        }

        public string[] GetCouponsByOrderId(int id)
        {
            comm.CommandText = "select couponId from OrderCoupons where orderId=" + id;
            comm.Connection = conn;
            conn.Open();
            CouponImplementation cpn = new CouponImplementation();
            SqlDataReader reader = comm.ExecuteReader();
            List<String> coupons = new List<string>();
            while (reader.Read())
            {
                int couponId = Convert.ToInt32(reader["couponId"]);
                coupons.Add(cpn.GetCouponById(couponId).code);
            }
            string[] array = new string[coupons.Count];
            int i = 0;
            foreach(String s in coupons)
            {
                array[i++] = s;
            }
            conn.Close();
            return array;
        }

        public List<Order> GetAll()
        {
            comm.CommandText = "select * from Orders;";
            comm.Connection = conn2;
            conn2.Open();
            SqlDataReader reader = comm.ExecuteReader();
            List<Order> list = new List<Order>();
            while (reader.Read())
            {
                int orderId = Convert.ToInt32(reader["orderId"]);
                int userId = Convert.ToInt32(reader["userId"]);
                int bookId = Convert.ToInt32(reader["bookId"]);
                DateTime orderTime = Convert.ToDateTime(reader["orderTime"].ToString());
                double basePrice = Convert.ToDouble(reader["basePrice"]);
                double sellingPrice = Convert.ToDouble(reader["sellingPrice"]);
                int s = Convert.ToInt32(reader["status"]);
                list.Add(new Order(orderId,userId,bookId,orderTime,basePrice,sellingPrice,s,this.GetCouponsByOrderId(orderId)));
            }
            conn2.Close();
            return list;
        }
        public Order GetOrderById(int id)
        {
            comm.CommandText = "select * from Orders where orderId=" + id + " ;";
            comm.Connection = conn2;
            conn2.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int orderId = Convert.ToInt32(reader["orderId"]);
                int userId = Convert.ToInt32(reader["userId"]);
                int bookId = Convert.ToInt32(reader["bookId"]);
                DateTime orderTime = Convert.ToDateTime(reader["orderTime"].ToString());
                double basePrice = Convert.ToDouble(reader["basePrice"]);
                double sellingPrice = Convert.ToDouble(reader["sellingPrice"]);
                int s = Convert.ToInt32(reader["status"]);


                conn2.Close();
                return (new Order(orderId, userId, bookId, orderTime, basePrice, sellingPrice, s, this.GetCouponsByOrderId(orderId)));

            }
            conn2.Close();
            return null;
        }

        public List<Order> GetOrderByUserId(int id)
        {
            comm.CommandText = "select * from Orders where userId="+id+";";
            comm.Connection = conn2;
            conn2.Open();
            SqlDataReader reader = comm.ExecuteReader();
            List<Order> list = new List<Order>();
            while (reader.Read())
            {
                int orderId = Convert.ToInt32(reader["orderId"]);
                int userId = Convert.ToInt32(reader["userId"]);
                int bookId = Convert.ToInt32(reader["bookId"]);
                DateTime orderTime = Convert.ToDateTime(reader["orderTime"].ToString());
                double basePrice = Convert.ToDouble(reader["basePrice"]);
                double sellingPrice = Convert.ToDouble(reader["sellingPrice"]);
                int s = Convert.ToInt32(reader["status"]);



                list.Add(new Order(orderId, userId, bookId, orderTime, basePrice, sellingPrice, s, this.GetCouponsByOrderId(orderId)));
            }
            conn2.Close();
            return list;
        }

        public int GetOrderId(Order order)
        {
            Debug.WriteLine("finding id");
            comm.CommandText = "select orderId from Orders where userId=" + order.userId + " and bookId="+order.bookId+" and orderTime = '"+order.orderTime.ToString()+"' order by orderId desc;";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int orderId = Convert.ToInt32(reader["orderId"]);
                conn.Close();
                Debug.WriteLine("id ");
                return orderId;
            }
            conn.Close();
            return 0;
        }
        public int Place(Order order)
        {
            DateTime t = DateTime.Now;
            order.orderTime = t;
            comm.CommandText = "insert into Orders values(" +order.userId+","+order.bookId+ ",'"+t.ToString()+"',"+new BookImplementation().GetBookById(order.bookId).price+","+CouponImplementation.ApplyCoupons(order)+",1);";
            comm.Connection = conn;
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            conn.Close();
            int id = GetOrderId(order);
            order.orderId = id;
            ApplyCoupons(order);
            return id;
        }
        public int Edit(Order order)
        {
            comm.CommandText = "update Orders set userId="+order.userId+ ",bookId="+order.bookId+",orderTime='"+order.orderTime.ToString()+"',basePrice="+order.basePrice+",sellingPrice="+order.sellingPrice+",status="+order.status+" where orderId="+order.orderId+";";
            comm.Connection = conn;
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            conn.Close();
            return rows;
        }
        public int Delete(Order order)
        {
            return Delete(order.orderId);
        }
        public int Delete(int id) 
        { 
            comm.CommandText="delete from ordercoupons where orderId="+id;
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close(); 
            comm.CommandText = "delete from Orders where orderId=" + id;
            comm.Connection = conn;
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            conn.Close();
            return rows;
        }
        public double ApplyCoupons(Order order)
        {
            SqlCommand comm = new SqlCommand();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm.Connection = conn;
            conn.Open();
            foreach (string coupon in order.coupons)
            {
                Coupon c = new CouponImplementation().GetCouponByCode(coupon);
                if (c is null)
                {
                    continue;
                }
                comm.CommandText = "insert into OrderCoupons values(" + order.orderId + "," + c.couponId + ");";
                comm.ExecuteNonQuery();
                //order.sellingPrice = order.sellingPrice * (100 - c.discount) / 100;
            }
            conn.Close();
            return order.sellingPrice;
        }
        public bool SetStatus(int id,int status)
        {
            Order order = GetOrderById(id);
            order.status = status;
            int rows = Edit(order);
            return rows > 0;
        }

        public bool Enable(int id)
        {
            return SetStatus(id, 1);
        }
        public bool Disable(int id)
        {
            return SetStatus(id, 0);
        }
    }
}