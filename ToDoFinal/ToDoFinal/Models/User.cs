using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoFinal.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Email yazilmalidir")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password yazilmalidir")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}