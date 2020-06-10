using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDone.Models;

namespace ToDone.Data
{
    public class UserDbContext : IdentityDbContext<ToDoUser>
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var admin = new IdentityRole 
            { 
                Id = "admin", 
                Name = "Administrator",
                ConcurrencyStamp = "3231ab94-86fd-4b02-8046-548edea028cb",
               
            };
            var moderator = new IdentityRole 
            { 
                Id = "moderator", 
                Name = "Moderator" ,
                ConcurrencyStamp = "d6d70432-9582-4aa7-ae8d-ed64c69f1add",
                
            };
            builder.Entity<IdentityRole>()
                .HasData(admin, moderator);

            
        }
    }
}
