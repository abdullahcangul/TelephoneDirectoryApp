using ReportService.Application.Utility.Results;
using ReportService.Domain.Entities;

namespace ReportService.Application.Abstractions.Services;

public interface IReportService:IBaseService<Report>
{
    public Task<IDataResult<List<Report>>> GetReportWithReportDetailAsync();
}