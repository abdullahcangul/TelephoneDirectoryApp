using AutoMapper;
using EventBus.Base.Abstraction;
using MediatR;
using PersonService.Application.IntegrationEvents.Events;
using PersonService.Application.Utility;
using ReportService.Application.Abstractions.Services;
using ReportService.Application.Utility.Results;
using ReportService.Domain;
using ReportService.Domain.Entities;

namespace PersonService.Application.Features.Commands.ReportCommand.CreateReport;

public class CreateReportCommandHandler:IRequestHandler<CreateReportCommandRequest,IResult>
{
    private readonly IReportService _reportService;
    private readonly IEventBus _eventBus;

    public CreateReportCommandHandler(IReportService reportService, IEventBus eventBus)
    {
        _reportService = reportService;
        _eventBus = eventBus;
    }

    public async Task<IResult> Handle(CreateReportCommandRequest request, CancellationToken cancellationToken)
    {
        var report = new Report()
        {
            Name = request.Name,
            RequestDate = DateTime.UtcNow,
            ReportStatusEnum = ReportStatusEnum.Preparing
        };
        var reportResult = await  _reportService.AddAsync(report);
        if (reportResult.Succes)
        {
            _eventBus.Publish(new ReportCreateIntegrationEvent(){ReportUUID = reportResult.Data.UUID});
            return new SuccessResult(Messages.CREATE_REPORT_REQUEST);
        }

        return new ErrorResult(Messages.ERROR_GET_REPORT_REQUEST);

    }
}