namespace MediatR.Domain.Abstractions;

public abstract class Entity
{
    protected Entity(long id)
    {
        Id = id;
    }

    public long Id { get; set; }
}
