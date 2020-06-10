using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDone.Models.DTOs
{
    public class UserWithToken
    {
        public string Token { get; set; }
        public string UserId { get; set; }

    }
}
