using MediatR.Domain.Abstractions;
using MediatR.Domain.Entities;
using MediatR.Repository.Contexto;
using Microsoft.EntityFrameworkCore;

namespace MediatR.Repository.Repository;
internal class PersonRepository(AppDbContext Context) : IPersonRepository
{
    public async Task<Person> AddPerson(Person person)
    {
        ArgumentNullException.ThrowIfNull(person);

        await Context.Persons.AddAsync(person);

        return person;
    }

    public async Task DeletePerson(long id)
    {
        var person = await GetPersonId(id);
        Context.Persons.Remove(person);
    }

    public async Task<IEnumerable<Person>> GetAll()
    {
        var persons = await Context.Persons.ToListAsync();
        return persons ?? Enumerable.Empty<Person>();
    }

    public async Task<Person> GetPersonId(long id)
    {
        return await Context.Persons.SingleAsync(x => x.Id == id);
    }

    public Person UpdatePerson(Person person)
    {
        ArgumentNullException.ThrowIfNull(person);
        Context.Persons.Update(person);
        return person;
    }
}
