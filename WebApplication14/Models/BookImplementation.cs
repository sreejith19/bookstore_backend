using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
//using System.Data.SqlClient;
//using System.Configuration;
using System.Security.Cryptography;

namespace WebApplication14.Models
{
    public class BookImplementation:IBookRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public BookImplementation()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
        public List<Book> GetBooks()
        {
            comm.CommandText = "select * from Books where status=1 order by year desc;";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            List<Book> list = new List<Book>();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["bookId"]);
                int catId = Convert.ToInt32(reader["catId"]);
                string title = reader["title"].ToString();
                string isbn = reader["isbn"].ToString();
                int year = Convert.ToInt32(reader["year"]);
                double price = Convert.ToDouble(reader["price"]);
                string desc = reader["description"].ToString();
                string pos = reader["position"].ToString();
                int s = Convert.ToInt32(reader["status"]);
                string img = reader["image"].ToString();
                string author = reader["author"].ToString();

                list.Add(new Book(id,catId, title,isbn,year,price, desc, pos, s, img, author));
            }
            conn.Close();
            return list;
        }
        public Book GetBookById(int bookId)
        {
            comm.CommandText = "select * from Books where bookId=" + bookId+ " and status=1;";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["bookId"]);
                int catId = Convert.ToInt32(reader["catId"]);
                string title = reader["title"].ToString();
                string isbn = reader["isbn"].ToString();
                int year = Convert.ToInt32(reader["year"]);
                double price = Convert.ToDouble(reader["price"]);
                string desc = reader["description"].ToString();
                string pos = reader["position"].ToString();
                int s = Convert.ToInt32(reader["status"]);
                string img = reader["image"].ToString();
                string author = reader["author"].ToString();
                return new Book(id, catId, title, isbn, year, price, desc, pos, s, img, author);
            }
            conn.Close();
            return null;
        }
        public List<Book> GetBooksByCatId(int cId)
        {
            comm.CommandText = "select * from Books where catId="+cId+ " and status=1 order by year desc;";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            List<Book> list = new List<Book>();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["bookId"]);
                int catId = Convert.ToInt32(reader["catId"]);
                string title = reader["title"].ToString();
                string isbn = reader["isbn"].ToString();
                int year = Convert.ToInt32(reader["year"]);
                double price = Convert.ToDouble(reader["price"]);
                string desc = reader["description"].ToString();
                string pos = reader["position"].ToString();
                int s = Convert.ToInt32(reader["status"]);
                string img = reader["image"].ToString();
                string author = reader["author"].ToString();

                list.Add(new Book(id, catId, title, isbn, year, price, desc, pos, s, img, author));
            }
            conn.Close();
            return list;
        }

        public List<Book> GetBooksByName(string name)
        {
            comm.CommandText = "select * from Books where title='" + name + "' and status=1 order by year desc;;";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            List<Book> list = new List<Book>();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["bookId"]);
                int catId = Convert.ToInt32(reader["catId"]);
                string title = reader["title"].ToString();
                string isbn = reader["isbn"].ToString();
                int year = Convert.ToInt32(reader["year"]);
                double price = Convert.ToDouble(reader["price"]);
                string desc = reader["description"].ToString();
                string pos = reader["position"].ToString();
                int s = Convert.ToInt32(reader["status"]);
                string img = reader["image"].ToString();
                string author = reader["author"].ToString();

                list.Add(new Book(id, catId, title, isbn, year, price, desc, pos, s, img, author));
            }
            conn.Close();
            return list;
        }
        public Book GetBooksByIsbn(string isb)
        {
            comm.CommandText = "select * from Books where isbn='" + isb + "' and status=1;";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["bookId"]);
                int catId = Convert.ToInt32(reader["catId"]);
                string title = reader["title"].ToString();
                string isbn = reader["isbn"].ToString();
                int year = Convert.ToInt32(reader["year"]);
                double price = Convert.ToDouble(reader["price"]);
                string desc = reader["description"].ToString();
                string pos = reader["position"].ToString();
                int s = Convert.ToInt32(reader["status"]);
                string img = reader["image"].ToString();
                string author = reader["author"].ToString();

                return new Book(id, catId, title, isbn, year, price, desc, pos, s, img, author);
            }
            conn.Close();
            return null;
        }
        public List<Book> GetBooksByAuthor(string auth)
        {
            comm.CommandText = "select * from Books where author='" + auth + "' and status=1 order by year desc;;";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            List<Book> list = new List<Book>();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["bookId"]);
                int catId = Convert.ToInt32(reader["catId"]);
                string title = reader["title"].ToString();
                string isbn = reader["isbn"].ToString();
                int year = Convert.ToInt32(reader["year"]);
                double price = Convert.ToDouble(reader["price"]);
                string desc = reader["description"].ToString();
                string pos = reader["position"].ToString();
                int s = Convert.ToInt32(reader["status"]);
                string img = reader["image"].ToString();
                string author = reader["author"].ToString();

                list.Add(new Book(id, catId, title, isbn, year, price, desc, pos, s, img, author));
            }
            conn.Close();
            return list;
        }
        public int AddBook(Book book)
        {
            comm.CommandText = "insert into Books values("+book.bookId+","+book.catId+",'"+book.title+"','"+book.isbn+"',"+book.year+","+book.price+",'"+book.description+"','"+book.position+"',"+book.status+",'"+book.image+"','"+book.author+"');";
            comm.Connection = conn;
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            conn.Close();
            return rows;
        }
        public int EditBook(Book book)
        {
            comm.CommandText = "update Books set catId="+book.catId+",title='"+book.title+"',isbn='"+book.isbn+"',year="+book.year+",price="+book.price+",description='"+book.description+"',position='"+book.position+"',status="+book.status+",image='"+book.image+"',author='"+book.author+"'where bookId="+book.bookId+";";
            comm.Connection = conn;
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            conn.Close();
            return rows;
        }
        public int DeleteBook(int bookId)
        {
            comm.CommandText = "delete from Books where bookId=" + bookId;
            comm.Connection = conn;
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            conn.Close();
            return rows;
        }
    }
}