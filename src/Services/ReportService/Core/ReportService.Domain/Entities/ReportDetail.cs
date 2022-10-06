namespace ReportService.Domain.Entities;

public class ReportDetail:BaseEntity
{
    public int PersonCount { get; set; }
    public int TelNoCount { get; set; }
    public string Address { get; set; }

    public int ReportUUID { get; set; }
    public Report Report { get; set; }
}