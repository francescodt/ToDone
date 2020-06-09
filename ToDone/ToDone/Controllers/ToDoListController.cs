using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDone.Data.API;
using ToDone.Models;
using ToDone.Models.DTOs;

namespace ToDone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : Controller
    {
        private readonly IToDoRepository toDoRepository; 

        public ToDoListController (IToDoRepository toDoRepository)
        {
            this.toDoRepository = toDoRepository;
        }

        public async Task<ActionResult<ToDoListDTO>> Index()
        {
            return Ok(await toDoRepository.GetToDoList());
        }
    }
}