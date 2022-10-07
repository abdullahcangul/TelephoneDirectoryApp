using EventBus.Base.Events;

namespace PersonService.Application.IntegrationEvents.Events;

public class ReportCreateIntegrationEvent: IntegrationEvent
{
    public Guid ReportUUID { get; set; }
}