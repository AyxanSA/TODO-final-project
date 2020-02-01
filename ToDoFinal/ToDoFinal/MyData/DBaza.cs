using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ToDoFinal.Models;

namespace ToDoFinal.MyData
{
    public class DBaza : DbContext
    {
        public DbSet<User> Users {get;set;}
        public DbSet<ToDos> ToDos { get; set; }
        public DbSet<Category> Categories { get; set; }
    }

}