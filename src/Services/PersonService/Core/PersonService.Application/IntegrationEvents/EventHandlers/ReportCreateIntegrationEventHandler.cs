
using EventBus.Base.Abstraction;
using PersonService.Application.Abstractions.Services;
using PersonService.Application.IntegrationEvents.Events;

namespace PersonService.Application.IntegrationEvents.EventHandlers;

public class ReportCreateIntegrationEventHandler: IIntegrationEventHandler<ReportCreateIntegrationEvent>
{
    private readonly IContactService _contactService;
    private readonly IEventBus _eventBus;

    public ReportCreateIntegrationEventHandler(IContactService contactService, IEventBus eventBus)
    {
        _contactService = contactService;
        _eventBus = eventBus;
    }
    
    public async Task Handle(ReportCreateIntegrationEvent @event)
    {
       var dataResult=await _contactService.GetReports();
       if (dataResult.Succes)
       {
           ReportCreatedIntegrationEvent reportCreatedIntegrationEvent = new ReportCreatedIntegrationEvent();
           reportCreatedIntegrationEvent.ReportUUID = @event.ReportUUID;
           reportCreatedIntegrationEvent.Reports = dataResult.Data;
           _eventBus.Publish(reportCreatedIntegrationEvent);
       }
    }
}