using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc5Test.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        public virtual IList<Genre> Genres { get; set; }
    }
}