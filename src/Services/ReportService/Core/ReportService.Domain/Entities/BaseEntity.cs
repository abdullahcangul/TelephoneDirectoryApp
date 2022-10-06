namespace ReportService.Domain.Entities;

public class BaseEntity
{
    public Guid UUID { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}