using Microsoft.EntityFrameworkCore;
using PersonService.Domain.Entities;
using PersonService.Persistence.Contexts.Mapping;

namespace PersonService.Persistence.Contexts;

public class TDPersonServiceDB:DbContext
{
    public TDPersonServiceDB(DbContextOptions options):base(options)
    {
     
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PersonMap());
        modelBuilder.ApplyConfiguration(new ContactMap());
        
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Contact> Contacts { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var datas = ChangeTracker
            .Entries<BaseEntity>();

        foreach (var data in datas)
        {
            _ = data.State switch
            {
                EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                _ => DateTime.UtcNow
            };
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}