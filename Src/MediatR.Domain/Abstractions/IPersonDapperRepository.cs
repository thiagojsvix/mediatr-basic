using DemoMediatR.Domain.Entities;

namespace DemoMediatR.Domain.Abstractions;

public interface IPersonDapperRepository
{
    Task<IEnumerable<Person>> GetPersons();
    Task<Person?> GetPersonById(long id);
}
