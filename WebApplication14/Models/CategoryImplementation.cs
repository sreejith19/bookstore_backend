using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;


namespace WebApplication14.Models
{
    public class CategoryImplementation: ICategoryrepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public CategoryImplementation()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
        public List<Category> getAll()
        {
            comm.CommandText = "select * from Category where status=1 order by position;";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            List<Category> list = new List<Category>();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["catId"]);
                string name = reader["catName"].ToString();
                string desc = reader["description"].ToString();
                string img = reader["catImage"].ToString();
                int s = Convert.ToInt32(reader["status"]);
                string pos = reader["position"].ToString();
                DateTime date = Convert.ToDateTime(reader["createdAt"].ToString());
                list.Add(new Category(id, name, desc, img, s, pos, date));
            }
            conn.Close();
            return list;
        }
        public Category getCategoryById(int cId)
        {
            comm.CommandText = "select * from Category where catId="+cId;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["catId"]);
                string name = reader["catName"].ToString();
                string desc = reader["description"].ToString();
                string img = reader["catImage"].ToString();
                int s = Convert.ToInt32(reader["status"]);
                string pos = reader["position"].ToString();
                DateTime date = Convert.ToDateTime(reader["createdAt"].ToString());
                return new Category(id, name, desc, img, s, pos, date);
            }
            conn.Close();
            return null;
        }
        public int addCategory(Category category)
        {
            comm.CommandText = "insert into Category values("+category.catId+ ",'" + category.catName+"','" + category.description+"','" + category.catImage + "',"+category.status+",'"+category.position+"','"+category.createdAt.ToString()+"');";
            comm.Connection = conn;
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            conn.Close();
            return rows;
        }
        public int editCategory(Category category)
        {
            comm.CommandText = "update Category set catName='" + category.catName + "',description='" + category.description + "',catImage='" + category.catImage + "',status=" + category.status + ",position='" + category.position + "',createdAt='" + category.createdAt.ToString() + "' where catId="+category.catId+";";
            comm.Connection = conn;
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            conn.Close();
            return rows;
        }
        public int deleteCategoryById(int catId)
        {
            comm.CommandText = "delete from Category where catId=" + catId;
            comm.Connection = conn;
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            conn.Close();
            return rows;
        }
    }
}