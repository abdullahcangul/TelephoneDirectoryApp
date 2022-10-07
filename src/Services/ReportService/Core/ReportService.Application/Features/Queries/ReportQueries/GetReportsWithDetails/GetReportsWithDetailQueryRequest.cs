using MediatR;
using ReportService.Application.Utility.Results;
using ReportService.Domain.Entities;

namespace PersonService.Application.Features.Queries.ReportQueries.GetReportsWithDetails;

public class GetReportsWithDetailQueryRequest:IRequest<IDataResult<List<Report>>>
{
    
}