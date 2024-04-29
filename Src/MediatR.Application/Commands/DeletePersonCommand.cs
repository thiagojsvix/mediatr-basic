using DemoMediatR.Domain.Entities;

using MediatR;

namespace DemoMediatR.Application.Commands;

public sealed class DeletePersonCommand : IRequest<Person?>
{
    public long Id { get; set; }
}
