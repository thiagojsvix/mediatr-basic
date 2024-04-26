namespace MediatR.Domain.Abstractions;

public interface IUnitOfWork
{
    IPersonRepository PersonRepository { get; }
    Task CommitAsync();
}
