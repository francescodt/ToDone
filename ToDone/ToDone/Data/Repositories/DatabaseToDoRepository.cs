using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDone.Data.API;
using ToDone.Models.DTOs;

namespace ToDone.Data.Repositories
{
    public class DatabaseToDoRepository : IToDoRepository
    {
        public Task<IEnumerable<ToDoListDTO>> GetToDoList()
        {
            throw new NotImplementedException();
        }
    }
}
