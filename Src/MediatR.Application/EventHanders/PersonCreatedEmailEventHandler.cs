using DemoMediatR.Application.Events;

using MediatR;

using Microsoft.Extensions.Logging;

namespace DemoMediatR.Application.EventHanders;

public class PersonCreatedEmailEventHandler(ILogger<PersonCreatedEmailEventHandler> logger) : INotificationHandler<PersonCreatedNotificationEvent>
{
    Task INotificationHandler<PersonCreatedNotificationEvent>.Handle(PersonCreatedNotificationEvent notification, CancellationToken cancellationToken)
    {
        // Send a confirmation email
        logger.LogInformation($"Confirmation email sent for : {notification.Person.LastName}");

        //lógica para enviar email   
        return Task.CompletedTask;
    }
}
