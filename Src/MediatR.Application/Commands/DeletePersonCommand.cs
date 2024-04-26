namespace MediatR.Application.Commands;

public sealed class DeletePersonCommand : IRequest
{
    public long Id { get; set; }
}
