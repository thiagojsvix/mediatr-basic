using MediatR.Domain.Entities;

namespace MediatR.Domain.Abstractions;
public interface IPersonRepository
{
    Task<IEnumerable<Person>> GetAll();
    Task<Person> GetPersonId(long id);
    Task<Person> AddPerson(Person person);
    Task<Person> UpdatePerson(Person person);
    Task DeletePerson(long id);
}

public interface IUnitOfWork
{
    IPersonRepository PersonRepository { get; }
    Task CommitAsync();
}
