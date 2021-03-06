﻿using System;

using MediatR;

using ToDoApp.Entity.Enums;

namespace ToDoApp.Application.ToDo.Commands.UpdateToDo
{
    public class UpdateToDoCommand : IRequest
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public Status Status { get; set; }

        public string Username { get; set; }
    }
}
