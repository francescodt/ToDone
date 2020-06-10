using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDone.Data.API;
using ToDone.Models;
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
                    CreatedBy = list.CreatedByUserId,
                })
                .ToListAsync();
            return list;
        }

        private readonly ToDoListDbContext _context;
        private readonly UserManager<ToDoUser> userManager;
        public DatabaseToDoRepository(ToDoListDbContext context, UserManager<ToDoUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        public async Task<ToDoListDTO> GetOneListItem(int id)
        {
            var listItem = await _context.Lists.FindAsync(id);

            if (listItem == null)
                return null;

            var user = await userManager.FindByIdAsync(listItem.CreatedByUserId);

            return new ToDoListDTO
            {
                Id = listItem.Id,
                CreatedBy = user == null ? null : $"{user.FirstName} {user.LastName}",
            };
        }

        public async Task DeleteListItem(int id)
        {
            var listItem = await _context.Lists.FindAsync(id);
            _context.Entry(listItem).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<ToDoListDTO> UpdateList(ToDoListDTO list, int id)
        {
            if(list.Id == id)
            {
                _context.Entry(list).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            return list;
        }

        public async Task CreateListItem(ToDoListDTO list)
        {
            _context.Entry(list).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }
    }
}
