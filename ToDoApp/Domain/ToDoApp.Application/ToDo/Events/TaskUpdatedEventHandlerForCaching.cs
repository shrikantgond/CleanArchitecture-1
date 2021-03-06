﻿using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Microsoft.Extensions.Logging;

namespace ToDoApp.Application.ToDo.Events
{
    public class TaskUpdatedEventHandlerForCaching : INotificationHandler<TaskUpdatedEvent>
    {
        private readonly ILogger<TaskUpdatedEventHandlerForCaching> _logger;

        public TaskUpdatedEventHandlerForCaching(ILogger<TaskUpdatedEventHandlerForCaching> logger)
        {
            _logger = logger;
        }

        public async Task Handle(TaskUpdatedEvent notification, CancellationToken cancellationToken)
        {
            await Task.Delay(1000);
            _logger.LogInformation($"Adding task to cache the following details: description-{notification.Description}, user-{notification.Email}, status-{notification.Status}.");
        }
    }
}
