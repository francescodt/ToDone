using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDone.Models
{
    public class ToDoList
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? DueDate { get; set; }

        public string Assignee { get; set; }


        
    }


}
