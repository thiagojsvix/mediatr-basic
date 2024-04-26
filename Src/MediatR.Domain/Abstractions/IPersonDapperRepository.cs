using MediatR.Domain.Entities;

namespace MediatR.Domain.Abstractions;

public interface IPersonDapperRepository
{
    Task<IEnumerable<Person>> GetPersons();
    Task<Person?> GetPersonById(long id);
}
