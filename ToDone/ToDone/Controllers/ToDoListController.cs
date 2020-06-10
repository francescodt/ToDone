﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDone.Data.API;
using ToDone.Data.Repositories;
using ToDone.Models;
using ToDone.Models.DTOs;

namespace ToDone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : Controller
    {
        private readonly Data.API.IToDoRepository toDoRepository; 

        public ToDoListController (Data.API.IToDoRepository toDoRepository)
        {
            this.toDoRepository = toDoRepository;
        }

        public async Task<ActionResult<ToDoListDTO>> Index()
        {
            return Ok(await toDoRepository.GetToDoList());
        }

        [HttpGet("{id}")]
        public async Task<ToDoListDTO> GetListItem(int id)
        {
            return await toDoRepository.GetOneListItem(id);
        }
    }
}