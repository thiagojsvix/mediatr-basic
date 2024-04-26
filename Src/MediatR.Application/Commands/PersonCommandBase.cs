using MediatR.Domain.Entities;

namespace MediatR.Application.Commands;

public abstract class PersonCommandBase : IRequest<Person>
{
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Gender { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public bool IsActive { get; private set; } = false;
}
