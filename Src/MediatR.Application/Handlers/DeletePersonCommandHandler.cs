using DemoMediatR.Application.Commands;
using DemoMediatR.Domain.Entities;

using MediatR;

namespace DemoMediatR.Application.Handlers;

public class DeletePersonCommandHandler() : IRequestHandler<DeletePersonCommand, Person?>
{
    public async Task<Person?> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        Person? deletedPerson = null;

        //var deletedPerson = await unitOfWork.PersonRepository.DeletePerson(request.Id) ?? 
        //    throw new InvalidOperationException("Member not found");

        //await unitOfWork.CommitAsync();

        return await Task.FromResult(deletedPerson);
    }
}
