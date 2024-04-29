using DemoMediatR.Domain.Entities;

using MediatR;
using MediatR.Application.Queries;

namespace DemoMediatR.Application.Handlers;
public class GetPersonsQueryHandler() : IRequestHandler<GetPersonsQuery, IEnumerable<Person>>
{
    public async Task<IEnumerable<Person>> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
    {
        var persons = Enumerable.Empty<Person>();
        //var persons = await repository.GetPersons();
        return await Task.FromResult(persons);
    }
}
