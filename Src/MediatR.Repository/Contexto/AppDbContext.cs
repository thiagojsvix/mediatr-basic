using DemoMediatR.Domain.Entities;
using DemoMediatR.Repository.Configuration;

using Microsoft.EntityFrameworkCore;

namespace DemoMediatR.Repository.Contexto;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Person> Persons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PersonConfiguration());

        base.OnModelCreating(modelBuilder);

        //https://www.youtube.com/watch?v=rAq5_9OG6YQ&t=1136s
    }
}
