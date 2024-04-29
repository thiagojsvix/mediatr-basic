using DemoMediatR.Domain.Abstractions;
using DemoMediatR.Domain.Entities;

using MediatR;
using MediatR.Application.Queries;

namespace DemoMediatR.Application.Handlers;

public class GetPersonByIdQueryHanlder() : IRequestHandler<GetPersonByIdQuery, Person?>
{
    public async Task<Person?> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        //var person = await repository.GetPersonById(request.Id);
        Person? person = default;
        
        return await Task.FromResult(person);
    }
}
