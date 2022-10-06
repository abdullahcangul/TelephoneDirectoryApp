using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReportService.Domain.Entities;

namespace PersonService.Persistence.Contexts.Mapping;

public class ReportDetailMap: IEntityTypeConfiguration<ReportDetail>
{
    public void Configure(EntityTypeBuilder<ReportDetail> builder)
    {
        builder.HasKey(c => c.UUID);
        
        builder.Property(r => r.Address).HasMaxLength(200);
        builder.Property(r => r.TelNoCount).IsRequired();
        builder.Property(r => r.PersonCount).IsRequired();
        
    }
}