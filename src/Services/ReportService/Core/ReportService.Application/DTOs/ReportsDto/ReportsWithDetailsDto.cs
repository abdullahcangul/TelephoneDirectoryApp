using ReportService.Domain;

namespace PersonService.Application.DTOs.ReportDtos;

public class ReportsWithDetailsDto:IDto
{
    public string Name { get; set; }
    public ReportStatusEnum ReportStatusEnum { get; set; }
    public DateTime RequestDate { get; set; }

    public List<ReportDetailsDto> ReportDetails { get; set; }
}

public class ReportDetailsDto:IDto
{
    public int PersonCount { get; set; }
    public int TelNoCount { get; set; }
    public string Address { get; set; }
}