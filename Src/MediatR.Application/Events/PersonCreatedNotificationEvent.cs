using DemoMediatR.Domain.Entities;

using MediatR;

namespace DemoMediatR.Application.Events;

public class PersonCreatedNotificationEvent(Person person) : INotification
{
    public Person Person { get; } = person;
}
