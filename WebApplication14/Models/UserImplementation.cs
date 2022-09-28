using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;

namespace WebApplication14.Models
{
    public class UserImplementation:IUserRepository
    {
        SqlCommand comm;
        SqlConnection conn;
        public UserImplementation()
        {
            comm = new SqlCommand();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
        }
        public List<User> GetAll()
        {
            comm.CommandText = "select * from Customer";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            List<User> list = new List<User>();
            while (reader.Read())
            {
                string username = reader["username"].ToString();
                string email = reader["email"].ToString();
                string phone = reader["phone"].ToString();
                string address = reader["address"].ToString();
                DateTime joinedAt = Convert.ToDateTime(reader["joinedAt"].ToString());
                list.Add(new User(username, email, phone, address, joinedAt));
            }
            conn.Close();
            Debug.WriteLine("Get all");
            return list;
        }
        public User GetUserById(int id)
        {
            comm.CommandText = "select * from Customer where userId=" + id + ";";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                string username = reader["username"].ToString();
                string email = reader["email"].ToString();
                string phone = reader["phone"].ToString();
                string address = reader["address"].ToString();
                DateTime joinedAt = Convert.ToDateTime(reader["joinedAt"].ToString());
                conn.Close();
                return (new User(username, email, phone, address, joinedAt));
            }
            conn.Close();
            return null;
        }
        public User GetUserByUserName(string username)
        {
            comm.CommandText = "select * from Customer where username='" + username + "';";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                string email = reader["email"].ToString();
                string phone = reader["phone"].ToString();
                string address = reader["address"].ToString();
                DateTime joinedAt = Convert.ToDateTime(reader["joinedAt"].ToString());
                conn.Close();
                return (new User(username, email, phone, address, joinedAt));
            }
            conn.Close();
            return null;
        }
        public User GetUserByEMail(string email)
        {
            comm.CommandText = "select * from Customer where email='" + email + "';";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                string username = reader["username"].ToString();
                string phone = reader["phone"].ToString();
                string address = reader["address"].ToString();
                DateTime joinedAt = Convert.ToDateTime(reader["joinedAt"].ToString());
                conn.Close();
                return (new User(username, email, phone, address, joinedAt));
            }
            conn.Close();
            return null;
        }
        public int AddUser(User user)
        {
            comm.CommandText = "insert into Customer values('" + user.username + "','" + user.email+ "','" + user.phone+ "','" + user.address+ "','" + user.joinedAt.ToString() + "');";
            comm.Connection = conn;
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            conn.Close();
            int id = GetUserIdByUserName(user.username);
            return id;
        }
        public int GetUserIdByUserName(string username)
        {
            comm.CommandText = "select * from Customer where username='" + username + "';";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int userId = Convert.ToInt32(reader["userId"]);
                conn.Close();
                return userId;
            }
            conn.Close();
            return 0;
        }
        public int EditUser(User user)
        {
            comm.CommandText = "update Customer set email='" + user.email + "',phone='" + user.phone+ "',address='" + user.address+ "',joinedAt='" + user.joinedAt.ToString()+ "' where username='" + user.username+ "';";
            comm.Connection = conn;
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            conn.Close();
            return rows;
        }
        public int DeleteUser(User user)
        {

            comm.CommandText = "delete from Customer where username='" + user.username+"';";
            comm.Connection = conn;
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            conn.Close();
            return rows;
        }
        public int ChangeUserName(string oldName, string newName)
        {
            comm.CommandText = "update Customer set username='" + newName + "' where username='" + oldName + "';";
            comm.Connection = conn;
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            conn.Close();
            return rows;
        }
    }
}