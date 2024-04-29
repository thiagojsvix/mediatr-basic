using DemoMediatR.Application.Commands;

namespace MediatR.Application.Commands;

public sealed class UpdatePersonCommand : PersonCommandBase
{
    public long Id { get; set; }
}
