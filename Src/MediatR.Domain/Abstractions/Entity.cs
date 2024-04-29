namespace DemoMediatR.Domain.Abstractions;

public abstract class Entity
{
    protected Entity()
    {
        Id = 0;
    }

    protected Entity(long id)
    {
        Id = id;
    }

    public long Id { get; set; }
}
