
using Microsoft.EntityFrameworkCore;
using PersonService.Persistence.Contexts.Mapping;
using ReportService.Domain.Entities;

namespace ReportService.Persistence.Contexts;

public class TDReportServiceContextDB:DbContext
{
    public TDReportServiceContextDB(DbContextOptions options):base(options)
    {
     
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ReportMap());
        modelBuilder.ApplyConfiguration(new ReportDetailMap());
        
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Report> Reports { get; set; }
    public DbSet<ReportDetail> ReportDetails { get; set; }

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