using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondMVC.ViewModels
{
    public class BookListViewModel
    {
        public List<BookViewModel> Books { get; set; }
        public string UserName { get; set; }
    }

}