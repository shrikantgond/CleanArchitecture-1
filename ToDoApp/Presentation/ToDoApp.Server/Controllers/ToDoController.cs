﻿using System.Linq;
using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ToDoApp.Application.ToDo.Commands.CreateToDo;
using ToDoApp.Application.ToDo.Commands.DeleteToDo;
using ToDoApp.Application.ToDo.Commands.UpdateToDo;
using ToDoApp.Application.ToDo.Queries;

namespace ToDoApp.Server.Controllers
{
    [Route("api/todo")]
    [ApiController]
    [Authorize]
    public class ToDoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ToDoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetToDoList()
        {
            var result = await _mediator.Send(new GetToDoListQuery(User.Identity.Name));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateToDo(CreateToDoCommand command)
        {
            command.Username = User.Identity.Name;
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateToDo(UpdateToDoCommand command)
        {
            command.Username = User.Identity.Name;
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteToDo(DeleteToDoCommand command)
        {
            command.Username = User.Identity.Name;
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}