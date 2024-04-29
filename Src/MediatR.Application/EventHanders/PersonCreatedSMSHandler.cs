using DemoMediatR.Application.EventHanders;
using DemoMediatR.Application.Events;

using Microsoft.Extensions.Logging;

namespace MediatR.Application.EventHanders;

public class PersonCreatedSMSHandler(ILogger<PersonCreatedEmailHandler> logger) : INotificationHandler<PersonCreatedNotification>
{
    public Task Handle(PersonCreatedNotification notification, CancellationToken cancellationToken)
    {
        //send a confirmation SMS
        logger.LogInformation($"Confirmation sms sent for : {notification.Person.FirstName}");

        //logica para enviar SMS
        return Task.CompletedTask;
    }
}
