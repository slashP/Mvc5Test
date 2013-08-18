using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mvc5Test.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        [Display(Name = "Sjanger")]
        [Required(ErrorMessage = "Sjanger må fylles ut")]
        public string GenreName { get; set; }

        public virtual IList<Book> Books { get; set; }
    }
}