using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BooksApp.Models
{
    public class Book
    {
        [Required(ErrorMessage ="Missing ISBN")]
        [StringLength(10, ErrorMessage ="More than 10 and less than 6 characters are not allowed",MinimumLength =6)]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Missing Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Missing Publisher")]
        public string Publisher { get; set; }

        [Display(Name ="Publication Date")]
        [DataType(DataType.DateTime, ErrorMessage ="Invalid Data")]
        [Required(ErrorMessage = "Missing Publication Date")]
        public DateTime DatePublished { get; set; }

        [Required(ErrorMessage = "Missing Price")]
        public decimal Price { get; set; }
    }
}