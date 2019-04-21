﻿using MediatR;
using System;

namespace ToDoApp.Application.ToDo.Commands.DeleteToDo
{
    public class DeleteToDoCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
