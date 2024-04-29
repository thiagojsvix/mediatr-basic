using DemoMediatR.Domain.Entities;

using MediatR;

namespace DemoMediatR.Application.Events;

public class PersonCreatedNotification(Person person) : INotification
{
    public Person Person { get; } = person;
}
