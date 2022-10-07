using MediatR;
using ReportService.Application.Utility.Results;
using ReportService.Domain.Entities;

namespace PersonService.Application.Features.Queries.ReportQueries.GetReports;

public class GetReportQueryRequest:IRequest<IDataResult<List<Report>>>
{
    
}