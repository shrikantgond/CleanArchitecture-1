﻿using System;
using ToDoApp.Entity.Enums;

namespace ToDoApp.Application.ToDo.Queries
{
    public class ToDoViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
    }
}
