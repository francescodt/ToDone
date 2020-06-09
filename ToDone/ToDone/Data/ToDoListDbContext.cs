using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDone.Data
{
    public class ToDoListDbContext : DbContext
    {

        public ToDoListDbContext (DbContextOptions<ToDoListDbContext> options) : base(options)
        {

        }
    }
}
