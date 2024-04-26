using FluentValidation;

using MediatR.Application.Commands;
using MediatR.Application.Events;
using MediatR.Domain.Abstractions;
using MediatR.Domain.Entities;

namespace MediatR.Application.Handlers;

public class CreatePersonsCommandHandler(IMediator mediator, IUnitOfWork unitOfWork, IValidator<CreatePersonCommand> validator) : IRequestHandler<CreatePersonCommand, Person>
{
    public async Task<Person> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        validator.ValidateAndThrow(request);

        var newMember = new Person(request.FirstName, request.LastName, request.Gender, request.Email, request.IsActive);

        await unitOfWork.PersonRepository.AddPerson(newMember);
        await unitOfWork.CommitAsync();

        await mediator.Publish(new PersonCreatedNotification(newMember), cancellationToken);

        return newMember;
    }
}
