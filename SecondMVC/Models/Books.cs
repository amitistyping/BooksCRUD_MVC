using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondMVC.Models
{
    [Table("TblBooks")]
    public class Books
    {
        public Books() { }
        [Key]
        public int BookId { get; set; }
        public string name { get; set; }
        public string author { get; set; }
        public int price { get; set; }
    }
}