using DemoMediatR.Application.Commands;
using DemoMediatR.Application.Events;
using DemoMediatR.Domain.Abstractions;
using DemoMediatR.Domain.Entities;

using MediatR;

namespace DemoMediatR.Application.Handlers;

public class CreatePersonsCommandHandler(IMediator mediator, IUnitOfWork unitOfWork) : IRequestHandler<CreatePersonCommand, Person>
{
    public async Task<Person> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var newMember = new Person(request.FirstName, request.LastName, request.Gender, request.Email, request.IsActive.Value);

        await unitOfWork.PersonRepository.AddPerson(newMember);
        await unitOfWork.CommitAsync();

        await mediator.Publish(new PersonCreatedNotificationEvent(newMember), cancellationToken);

        return newMember;
    }
}
