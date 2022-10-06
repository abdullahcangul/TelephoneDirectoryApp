using MediatR;
using PersonService.Application.Features.Queries.ReportQueries.GetReports;
using ReportService.Application.Abstractions.Services;
using ReportService.Application.Utility.Results;
using ReportService.Domain.Entities;

namespace PersonService.Application.Features.Queries.ReportQueries.GetReportsWithDetails;

public class GetReportsWithDetailQueryHandler:IRequestHandler<GetReportsWithDetailQueryRequest,IDataResult<List<Report>>>
{
    private readonly IReportService _reportService;
    private IRequestHandler<GetReportsWithDetailQueryRequest, IDataResult<List<Report>>> _requestHandlerImplementation;

    public GetReportsWithDetailQueryHandler(IReportService reportService)
    {
        _reportService = reportService;
    }

    public async Task<IDataResult<List<Report>>> Handle(GetReportsWithDetailQueryRequest request, CancellationToken cancellationToken)
    {
        return await _reportService.GetReportWithReportDetailAsync();

    }
}