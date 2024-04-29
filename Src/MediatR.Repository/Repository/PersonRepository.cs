using DemoMediatR.Domain.Abstractions;
using DemoMediatR.Domain.Entities;
using DemoMediatR.Repository.Contexto;

using Microsoft.EntityFrameworkCore;

namespace DemoMediatR.Repository.Repository;

public class PersonRepository(AppDbContext Context) : IPersonRepository
{
    public async Task<Person> AddPerson(Person person)
    {
        ArgumentNullException.ThrowIfNull(person);

        await Context.Persons.AddAsync(person);

        return person;
    }

    public async Task<Person?> DeletePerson(long id)
    {
        var member = await GetPersonId(id) ?? throw new InvalidOperationException("Member not found");
        Context.Persons.Remove(member);

        return member;
    }

    public async Task<IEnumerable<Person>> GetAll()
    {
        var persons = await Context.Persons.ToListAsync();
        return persons ?? Enumerable.Empty<Person>();
    }

    public async Task<Person?> GetPersonId(long id)
    {
        return await Context.Persons.SingleOrDefaultAsync(x => x.Id == id);
    }

    public Person UpdatePerson(Person person)
    {
        ArgumentNullException.ThrowIfNull(person);
        Context.Persons.Update(person);
        return person;
    }
}
