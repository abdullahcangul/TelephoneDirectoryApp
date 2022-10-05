using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonService.Domain.Entities;

namespace PersonService.Persistence.Contexts.Mapping;

public class PersonMap: IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(p => p.UUID);
        
        builder.Property(p => p.Name).HasMaxLength(50);
        builder.Property(p => p.Surname).HasMaxLength(50);

        builder.HasMany<Contact>(p => p.Contacts)
            .WithOne(c => c.Person)
            .HasForeignKey(c => c.PersonUUID);
    }
}