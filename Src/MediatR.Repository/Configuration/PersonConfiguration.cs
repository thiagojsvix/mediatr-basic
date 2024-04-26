using MediatR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediatR.Repository.Configuration;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.FirstName).HasMaxLength(100).IsRequired();
        builder.Property(m => m.LastName).HasMaxLength(100).IsRequired();
        builder.Property(m => m.Gender).HasMaxLength(10).IsRequired();
        builder.Property(m => m.Email).HasMaxLength(150).IsRequired();
        builder.Property(m => m.IsActive).IsRequired();

        builder.HasData(
            new Person(1, "Janis", "Joplin", "feminino", "janis@email.com", true),
            new Person(2, "Elvis", "Presley", "masculino", "elvis@email.com", true)
        );
    }
}
