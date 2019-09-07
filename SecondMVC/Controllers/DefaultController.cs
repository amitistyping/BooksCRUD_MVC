using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecondMVC.Models;
using SecondMVC.ViewModels;
using System.Data;
using System.Data.SqlClient;
using SecondMVC.DataAccessLayer;
using System.Collections;

namespace SecondMVC.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult GetView()
        {
            BookListViewModel bookListViewModel = new BookListViewModel();

            BookBusinessLayer bookBusinessLayer = new BookBusinessLayer();

            List<Books> books = bookBusinessLayer.GetBooks();
            List<BookViewModel> bookViewModels = new List<BookViewModel>();

            foreach (Books book in books)
            {
                BookViewModel bookViewModel = new BookViewModel();
                bookViewModel.BookId = book.BookId;
                bookViewModel.Name = book.name;
                bookViewModel.Author = book.author;
                bookViewModel.Price = book.price;
                if (book.price > 10)
                {
                    bookViewModel.AuthorColor = "Red";
                }
                bookViewModels.Add(bookViewModel);
            }
            bookListViewModel.Books = bookViewModels;
            bookListViewModel.UserName = "Admin";
            return View("MyView", bookListViewModel);
        }

        public ActionResult AddNew()
        {
            return View("AddBook");
        }

        [HttpPost]
        public ActionResult AddNew(Books books)
        {
            mBookDAL bookDAL = new mBookDAL();
            bookDAL.AddBook(books);
            return RedirectToAction("GetView");
        }

        [HttpPost]
        public ActionResult EditBook(Books books)
        {
            mBookDAL bookDAL = new mBookDAL();
            bookDAL.EditBookData(books);
            return RedirectToAction("GetView");
        }

        public ActionResult UpdateBook()
        {
            string stringB = Request.QueryString["id"];
            int PassB = Convert.ToInt32(stringB);
            mBookDAL mBookDAL = new mBookDAL();
            Books books = new Books();
            books = mBookDAL.DispBook(PassB);
            return View("EditBookView", books);
        }

        public ActionResult DeleteBook()
        {
            int PassBid = Convert.ToInt32(Request.QueryString["id"]);
            mBookDAL mBookDAL = new mBookDAL();
            mBookDAL.DelBookDAL(PassBid);
            return RedirectToAction("GetView");
        }

        [HttpGet]
        public ActionResult SearchBooks(string SearchBox)
        {
            BookListViewModel bookListViewModel = new BookListViewModel();

            BookBusinessLayer bookBusinessLayer = new BookBusinessLayer();

            List<Books> books = bookBusinessLayer.Search(SearchBox);
            List<BookViewModel> bookViewModels = new List<BookViewModel>();

            foreach (Books book in books)
            {
                BookViewModel bookViewModel = new BookViewModel();
                bookViewModel.BookId = book.BookId;
                bookViewModel.Name = book.name;
                bookViewModel.Author = book.author;
                bookViewModel.Price = book.price;                
                bookViewModels.Add(bookViewModel);
            }
            bookListViewModel.Books = bookViewModels;
            bookListViewModel.UserName = "Admin";
            return View("MyView", bookListViewModel);
        }




    }

    }

