using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SecondMVC.DataAccessLayer;
namespace SecondMVC.Models
{
    public class BookBusinessLayer
    {
        public List<Books> GetBooks()
        {
            mBookDAL mBook = new mBookDAL();
           // mBook.Database.Initialize(true);


            return mBook.Book.ToList();
            
        }

        public List<Books> Search(string SearchQuery)
        {
            mBookDAL mBook = new mBookDAL();

            return (mBook.Book.Where(x => x.name.StartsWith(SearchQuery)).ToList());
        }
    }
}