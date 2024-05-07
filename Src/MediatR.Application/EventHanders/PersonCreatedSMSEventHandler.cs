using DemoMediatR.Application.EventHanders;
using DemoMediatR.Application.Events;

using Microsoft.Extensions.Logging;

namespace MediatR.Application.EventHanders;

public class PersonCreatedSMSEventHandler(ILogger<PersonCreatedEmailEventHandler> logger) : INotificationHandler<PersonCreatedNotificationEvent>
{
    public Task Handle(PersonCreatedNotificationEvent notification, CancellationToken cancellationToken)
    {
        //envia confirmação SMS
        logger.LogInformation($"Confirmation sms sent for : {notification.Person.FirstName}");

        //logica para enviar SMS
        return Task.CompletedTask;
    }
}
