using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondMVC.ViewModels
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string AuthorColor { get; set; }
        public int Price { get; set; }

    }
}