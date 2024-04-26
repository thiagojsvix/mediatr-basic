using MediatR.Application.Queries;
using MediatR.Domain.Abstractions;
using MediatR.Domain.Entities;

namespace MediatR.Application.Handlers;

public class GetPersonByIdQueryHanlder(IPersonDapperRepository repository) : IRequestHandler<GetPersonByIdQuery, Person?>
{
    public async Task<Person?> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        var person = await repository.GetPersonById(request.Id);
        return person;
    }
}
