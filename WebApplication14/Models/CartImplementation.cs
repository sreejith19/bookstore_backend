using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication14.Models
{
    public class CartImplementation:ICartRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public CartImplementation()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
        public List<WishListEntry> GetWishList(int userId)
        {
            comm.CommandText = "select * from WishList where userId="+userId+";";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            List<WishListEntry> list = new List<WishListEntry>();
            while (reader.Read())
            {
                int bookId = Convert.ToInt32(reader["bookId"]);
                
                list.Add(new WishListEntry(userId,bookId));
            }
            conn.Close();
            return list;
        }
        public List<CartEntry> GetCart(int userId)
        {
            comm.CommandText = "select * from Cart where userId=" + userId + ";";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            List<CartEntry> list = new List<CartEntry>();
            while (reader.Read())
            {
                int bookId = Convert.ToInt32(reader["bookId"]);

                list.Add(new CartEntry(userId, bookId));
            }
            conn.Close();
            return list;
        }
        public bool AddToWishList(int userId, int bookId)
        {
            comm.CommandText = "insert into WishList values(" + userId + "," + bookId + ");";
            comm.Connection = conn;
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            conn.Close();
            return rows > 0;
        }
        public bool AddToCart(int userId, int bookId)
        {
            comm.CommandText = "insert into Cart values(" + userId + "," + bookId + ");";
            comm.Connection = conn;
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            conn.Close();
            return rows > 0;
        }
        public bool RemoveFromWishList(int userId, int bookId)
        {
            comm.CommandText = "delete from WishList where userId=" + userId +"and bookId="+bookId+";";
            comm.Connection = conn;
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            conn.Close();
            return rows>0;
        }
        public bool RemoveFromCart(int userId, int bookId)
        {
            comm.CommandText = "delete from Cart where userId=" + userId + "and bookId=" + bookId + ";";
            comm.Connection = conn;
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            conn.Close();
            return rows > 0;
        }
    }
}