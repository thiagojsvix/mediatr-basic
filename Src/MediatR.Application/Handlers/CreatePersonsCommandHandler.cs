using DemoMediatR.Application.Commands;
using DemoMediatR.Application.Events;
using DemoMediatR.Domain.Entities;

using MediatR;

namespace DemoMediatR.Application.Handlers;

public class CreatePersonsCommandHandler(IMediator mediator) : IRequestHandler<CreatePersonCommand, Person>
{
    public async Task<Person> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        //validator.ValidateAndThrow(request);

        var newMember = new Person(request.FirstName, request.LastName, request.Gender, request.Email, request.IsActive.Value);

        //await unitOfWork.PersonRepository.AddPerson(newMember);
        //await unitOfWork.CommitAsync();

        await mediator.Publish(new PersonCreatedNotification(newMember), cancellationToken);

        return newMember;
    }
}
