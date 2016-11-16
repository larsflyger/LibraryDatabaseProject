using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Library.Models
{
    public class book
    {
        [Required]
        [Key]
        public int bookID { get; set; }
     
        [Required]
        public string bookName { get; set; }
        [Required]
        public string bookAuthor { get; set; }
        [Required]
        public int  bookEdition { get; set; }
        [Required]
        public decimal bookPrice { get; set; }
        [Required]
        public string bookPublication { get; set; }
    }
}