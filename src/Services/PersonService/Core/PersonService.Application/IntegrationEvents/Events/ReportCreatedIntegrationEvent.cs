using EventBus.Base.Events;
using PersonService.Application.DTOs.ReportDto;

namespace PersonService.Application.IntegrationEvents.Events;

public class ReportCreatedIntegrationEvent: IntegrationEvent
{
    public Guid ReportUUID { get; set; }
    public List<ReportDto> Reports { get; set; }
}