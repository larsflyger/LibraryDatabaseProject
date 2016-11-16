using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Library.Models
{
    public class manager
    {
        [Required]
        [Key]
        public int managerID { get; set; }
        [Required]
        public string managerName { get; set; }
    
    }
}