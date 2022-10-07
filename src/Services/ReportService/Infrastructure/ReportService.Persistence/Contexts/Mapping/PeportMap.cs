using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReportService.Domain.Entities;

namespace PersonService.Persistence.Contexts.Mapping;

public class ReportMap: IEntityTypeConfiguration<Report>
{
    public void Configure(EntityTypeBuilder<Report> builder)
    {
        builder.HasKey(r => r.UUID);
        
        builder.Property(r => r.Name).HasMaxLength(50);
        builder.Property(r => r.RequestDate).IsRequired();
        builder.Property(r => r.RequestDate).IsRequired();

        builder.HasMany<ReportDetail>(p => p.ReportDetails)
            .WithOne(c => c.Report)
            .HasForeignKey(c => c.ReportUUID)
            .OnDelete(DeleteBehavior.Cascade);
    }
}