using MediatR.Domain.Entities;

namespace MediatR.Application.Events;

public class PersonCreatedNotification(Person person) : INotification
{
    public Person Person { get; } = person;
}
