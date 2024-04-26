using MediatR.Application.Queries;
using MediatR.Domain.Abstractions;
using MediatR.Domain.Entities;

namespace MediatR.Application.Handlers;
public class GetPersonsQueryHandler(IPersonDapperRepository repository) : IRequestHandler<GetPersonsQuery, IEnumerable<Person>>
{
    public async Task<IEnumerable<Person>> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
    {
        var persons = await repository.GetPersons();
        return persons;
    }
}
