using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDone.Models;

namespace ToDone.Data
{
    public class ToDoListDbContext : DbContext
    {

        public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options) : base(options)
        {

        }

        public DbSet<ToDoList>Lists {get; set;}
    }
}
