using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SecondMVC.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SecondMVC.DataAccessLayer
{
    public class mBookDAL : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>().ToTable("TblBook");
            base.OnModelCreating(modelBuilder);
        }

        public void AddBook(Books book)
        {
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["mBookDAL"].ConnectionString
            };
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string name = book.name;
            string author = book.author;
            int price = book.price;
            SqlCommand command = new SqlCommand("AddInfo", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("bn", name);
            command.Parameters.AddWithValue("ba", author);
            command.Parameters.AddWithValue("bp", price);
            command.ExecuteNonQuery();
            command.Dispose();
        }

        public Books DispBook(int id)
        {
            int Bid = id;
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["mBookDAL"].ConnectionString
            };
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand("SELECT * FROM TblBook WHERE BookId =" + Bid, connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            Books books = new Books();
            books.BookId = Convert.ToInt32(ds.Tables[0].Rows[0]["BookId"]);
            books.name = ds.Tables[0].Rows[0]["name"].ToString();
            books.author = ds.Tables[0].Rows[0]["author"].ToString();
            books.price = Convert.ToInt32(ds.Tables[0].Rows[0]["price"]);
            return (books);
        }

        public void EditBookData(Books books)
        {
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["mBookDAL"].ConnectionString
            };
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand("EditBookSP", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@bid", books.BookId);
            command.Parameters.AddWithValue("@bn", books.name);
            command.Parameters.AddWithValue("@ba", books.author);
            command.Parameters.AddWithValue("@bp", books.price);
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
        }

        public void DelBookDAL(int Bookid)
        {
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["mBookDAL"].ConnectionString
            };
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand("DelBookSP", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Bid", Bookid);
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
        }

        public DbSet<Books> Book { get; set; }
    }

}