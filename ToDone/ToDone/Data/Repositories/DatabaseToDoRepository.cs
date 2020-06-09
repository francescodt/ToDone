using Microsoft.EntityFrameworkCore;
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
        public async Task<IEnumerable<ToDoListDTO>> GetToDoList()
        {
            var list = await _context.Lists
                .Select(list => new ToDoListDTO
                {
                    Id = list.Id,
                    Name = list.Name,
                    DueDate = list.DueDate,
                    Assignee = list.Assignee,
                })
                .ToListAsync();
            return list;
        }

        private readonly ToDoListDbContext _context;
        public DatabaseToDoRepository(ToDoListDbContext context)
        {
            _context = context;
        }

    }
}
