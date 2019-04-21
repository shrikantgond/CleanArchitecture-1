﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoApp.Application.ToDo.Commands.CreateTask;
using ToDoApp.Application.ToDo.Commands.DeleteToDo;
using ToDoApp.Application.ToDo.Commands.UpdateToDo;
using ToDoApp.Application.ToDo.Queries;

namespace ToDoApp.Server.Controllers
{
    public class ToDoController : ControllerBase
    {
        private readonly IMediator mediator;

        public ToDoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetToDoList()
        {
            var result = await mediator.Send(new GetToDoListQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateToDo([FromBody]CreateToDoCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateToDo([FromBody]UpdateToDoCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteToDo([FromBody]DeleteToDoCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}