using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class checkout
    {
        [Required]
        [Key]
        public int checkoutID { get; set; }
        [Required]
       [ForeignKey("book")]
        public int bookID { get; set; }
        [Required]
        
        public virtual book book { get; set; }
        [ForeignKey("student")]
        public int studentID { get; set; }
        [Required]
        
        public virtual student student { get; set; }
        [ForeignKey("manager")]
        public int  managerID {get;set;}
        [Required]
        
        public virtual manager manager { get; set; }
        [Required]
        public string checkoutDate  { get; set; }
        [Required]
        public string returnDate { get; set; }
    }
}