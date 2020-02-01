using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoFinal.Models
{
    public class ToDos
    {
        public int Id { get; set; }
        [Required]
        public string Tittle { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}