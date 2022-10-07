using AutoMapper;
using EventBus.Base.Abstraction;
using PersonService.Application.IntegrationEvents.Events;
using ReportService.Application.Abstractions.Services;
using ReportService.Domain;
using ReportService.Domain.Entities;

namespace PersonService.Application.IntegrationEvents.EventHandlers;

public class ReportCreatedIntegrationEventHandler: IIntegrationEventHandler<ReportCreatedIntegrationEvent>
{
    private readonly IReportService _reportService;
    private readonly IMapper _mapper;

    public ReportCreatedIntegrationEventHandler(IReportService reportService, IMapper mapper)
    {
        _reportService = reportService;
        _mapper = mapper;
    }

    public async Task Handle(ReportCreatedIntegrationEvent @event)
    {
        var resultResult=await _reportService.GetByIdAsync(@event.ReportUUID);
        if (resultResult.Succes)
        {
            resultResult.Data.ReportStatusEnum = ReportStatusEnum.Completed;
            resultResult.Data.ReportDetails = _mapper.Map<List<ReportDetail>>(@event.Reports);
           await _reportService.UpdateAsync(resultResult.Data);
        }
    }
}