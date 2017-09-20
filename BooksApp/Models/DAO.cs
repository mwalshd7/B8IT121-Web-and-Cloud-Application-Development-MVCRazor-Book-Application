using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

namespace BooksApp.Models
{
    public class DAO
    {
        SqlConnection conn;
        public string message = "";
        public void Connection()
        {
            conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        }

        public int Insert(Book book)
        {
            int count = 0;
            Connection();
            SqlCommand cmd = new SqlCommand("uspInsertBookData", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@isbn", book.ISBN);
            cmd.Parameters.AddWithValue("@title", book.Title);
            cmd.Parameters.AddWithValue("@publisher", book.Publisher);
            cmd.Parameters.AddWithValue("@datePublished", book.DatePublished);
            cmd.Parameters.AddWithValue("@price",book.Price);
            try
            {
                conn.Open();
                count = cmd.ExecuteNonQuery();
            }catch(SystemException ex)
            {
                message = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return count;
        }

        public List<Book> ShowAll()
        {
            List<Book> list = new List<Book>();
            Connection();
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("uspAllBooks", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Book book = new Book();
                    book.ISBN = reader["isbn"].ToString();
                    book.Title = reader["title"].ToString();
                    book.Publisher = reader["publisher"].ToString();
                    book.DatePublished = DateTime.Parse(reader["datePublished"].ToString());
                    book.Price = decimal.Parse(reader["price"].ToString());
                    list.Add(book);
                }
            }catch(Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return list;
        }

    }
}