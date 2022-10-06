using ReportService.Domain;

namespace PersonService.Application.DTOs.ReportDtos;

public class ReportDto:IDto
{
    public string Name { get; set; }
    public ReportStatusEnum ReportStatusEnum { get; set; }
    public DateTime RequestDate { get; set; }

}