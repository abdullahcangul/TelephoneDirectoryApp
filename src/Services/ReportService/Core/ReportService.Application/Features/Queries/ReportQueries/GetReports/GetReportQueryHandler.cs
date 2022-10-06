using MediatR;
using ReportService.Application.Abstractions.Services;
using ReportService.Application.Utility.Results;
using ReportService.Domain.Entities;

namespace PersonService.Application.Features.Queries.ReportQueries.GetReports;

public class GetReportQueryHandler:IRequestHandler<GetReportQueryRequest,IDataResult<List<Report>>>
{
    private readonly IReportService _reportService;

    public GetReportQueryHandler(IReportService reportService)
    {
        _reportService = reportService;
    }

    public async Task<IDataResult<List<Report>>> Handle(GetReportQueryRequest request, CancellationToken cancellationToken)
    {
       return await _reportService.GetAllAsync();
    }
}