using EventBus.Base.Events;
using PersonService.Application.DTOs.ReportDtos;

namespace PersonService.Application.IntegrationEvents.Events;

public class ReportCreatedIntegrationEvent: IntegrationEvent
{
    public Guid ReportUUID { get; set; }
    public List<ReportDetailsDto> Reports { get; set; }
}