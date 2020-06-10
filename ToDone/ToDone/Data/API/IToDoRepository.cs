using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDone.Models.DTOs;


namespace ToDone.Data.API
{
    public interface IToDoRepository
    {
        Task<IEnumerable<ToDoListDTO>> GetToDoList();
        Task<ToDoListDTO> GetOneListItem(int id);
        Task DeleteListItem(int id);
        Task<ToDoListDTO> UpdateList(ToDoListDTO list, int id);
        Task CreateListItem(ToDoListDTO list);
    }
}
