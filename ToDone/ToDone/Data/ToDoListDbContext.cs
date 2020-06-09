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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoList>().HasData(
                new ToDoList
                {
                    Id = 1,
                    Name = "Fake Company",
                    DueDate = new DateTime(2020, 6, 08, 20, 49, 20, DateTimeKind.Utc),
                    Assignee = "Francesco",
                });
        }

        public DbSet<ToDoList>Lists {get; set;}
    }
}
