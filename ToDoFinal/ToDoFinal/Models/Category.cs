using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoFinal.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int UserId { get; set; }
        public bool isDeleted { get; set; } = false;
        public virtual User User { get; set; }

        public virtual ICollection<ToDos> ToDoLists { get; set; }
    }
}