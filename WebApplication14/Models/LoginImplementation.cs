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
    public class LoginImplementation:ILoginRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public LoginImplementation()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["security"].ConnectionString);
            comm = new SqlCommand();
        }
        public Boolean Validate(Credentials credentials,string type)
        {
            comm.CommandText = "select * from " + type + " where name = '" + credentials.userName + "' and password = '" + credentials.password + "';";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.Read())
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;
        }
        public int GetIdFromUser(Credentials credentials)
        {
            comm.CommandText = "select * from  customer where name = '" + credentials.userName + "';";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["id"]);
                conn.Close();
                return id;
            }
            conn.Close();
            return 0;
        }
        public int ChangePassword(Credentials credentials, string new_password) 
        {
            comm.CommandText = "update customer set password = '"+new_password+ "' where name = '" + credentials.userName + "' and password = '" + credentials.password+"';";
            comm.Connection = conn;
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            conn.Close();
            return rows;
        }
        public int AddUser(Credentials credentials)
        {
            if (UserExists(credentials.userName))
            {
                Debug.WriteLine("Existing user");
                return -1;
            }
            comm.CommandText = "insert into customer values('" + credentials.userName + "','" + credentials.password + "');";
            comm.Connection = conn;
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            conn.Close();
            int id = GetIdFromUser(credentials);
            return id;
        }

        public bool UserExists(string name) 
        {
            comm.CommandText = "select * from customer where name = '" + name + "';";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.Read())
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;
        }
        public int DeleteUser(Credentials credentials)
        {
            comm.CommandText = "delete from customer where name = '" + credentials.userName+"' and password = '"+credentials.password+"';";
            comm.Connection = conn;
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            conn.Close();
            return rows;
        }
    }
}