using DemoMediatR.Domain.Entities;

namespace MediatR.Application.Queries;
public sealed class GetPersonByIdQuery : IRequest<Person>
{
    public long Id { get; set; }
}
