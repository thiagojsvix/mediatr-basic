using DemoMediatR.Domain.Entities;

using MediatR;

namespace DemoMediatR.Application.Commands;

public abstract class PersonCommandBase : IRequest<Person>
{
    public string FirstName { get;  set; } = string.Empty;
    public string LastName { get;  set; } = string.Empty;
    public string Gender { get;  set; } = string.Empty;
    public string Email { get;  set; } = string.Empty;
    public bool? IsActive { get;  set; } = false;
}
