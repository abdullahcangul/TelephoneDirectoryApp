namespace ReportService.Domain.Entities;

public class Report:BaseEntity
{
    public string Name { get; set; }
    public ReportStatusEnum ReportStatusEnum { get; set; }
    public DateTime RequestDate { get; set; }

    public List<ReportDetail> ReportDetails { get; set; }
}