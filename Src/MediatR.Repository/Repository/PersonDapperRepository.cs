using System.Data;

using Dapper;

using MediatR.Domain.Abstractions;
using MediatR.Domain.Entities;

namespace MediatR.Repository.Repository;

public class PersonDapperRepository(IDbConnection dbConnection) : IPersonDapperRepository
{
    public async Task<Person?> GetPersonById(long id)
    {
        string query = "SELECT * FROM Persons WHERE Id = @Id";
        var result = await dbConnection.QueryFirstOrDefaultAsync<Person>(query, new { Id = id });
        return result;
    }

    public async Task<IEnumerable<Person>> GetPersons()
    {
        string query = "SELECT * FROM Persons";
        return await dbConnection.QueryAsync<Person>(query);
    }
}
