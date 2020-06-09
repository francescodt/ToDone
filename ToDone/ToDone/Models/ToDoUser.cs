using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDone.Models
{
    public class ToDoUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //no I won't
    }
}
