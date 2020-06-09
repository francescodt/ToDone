using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDone.Models.DTOs
{
    public class ToDoListDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? DueDate { get; set; }

        public string Assignee { get; set; }


    }
}
