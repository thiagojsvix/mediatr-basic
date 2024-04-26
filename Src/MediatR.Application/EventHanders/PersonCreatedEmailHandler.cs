﻿using MediatR.Application.Events;

using Microsoft.Extensions.Logging;

namespace MediatR.Application.EventHanders;

public class PersonCreatedEmailHandler(ILogger<PersonCreatedEmailHandler> logger) : INotificationHandler<PersonCreatedNotification>
{
    Task INotificationHandler<PersonCreatedNotification>.Handle(PersonCreatedNotification notification, CancellationToken cancellationToken)
    {
        // Send a confirmation email
        logger.LogInformation($"Confirmation email sent for : {notification.Person.LastName}");

        //lógica para enviar email   
        return Task.CompletedTask;
    }
}