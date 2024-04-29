using DemoMediatR.Domain.Entities;

namespace DemoMediatR.Domain.Abstractions;

public interface IPersonRepository
{
    Task<IEnumerable<Person>> GetAll();
    Task<Person?> GetPersonId(long id);
    Task<Person> AddPerson(Person person);
    Person UpdatePerson(Person person);
    Task<Person?> DeletePerson(long id);
}
