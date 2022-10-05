using Microsoft.EntityFrameworkCore;
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
    }
}