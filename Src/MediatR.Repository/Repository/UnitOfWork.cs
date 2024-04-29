using DemoMediatR.Domain.Abstractions;
using DemoMediatR.Repository.Contexto;
using DemoMediatR.Repository.Repository;

namespace MediatR.Repository.Repository;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly AppDbContext _appDbContext;
    private readonly IPersonRepository? _personRepository;

    public UnitOfWork(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
        PersonRepository = _personRepository ?? new PersonRepository(_appDbContext);
    }

    public IPersonRepository PersonRepository { get; }

    public async Task CommitAsync()
    {
        await _appDbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _appDbContext.Dispose();
    }
}
