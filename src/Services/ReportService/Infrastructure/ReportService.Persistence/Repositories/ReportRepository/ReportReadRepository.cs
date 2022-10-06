using ReportService.Application.Repositories.ReportRepository;
using ReportService.Domain.Entities;
using ReportService.Persistence.Contexts;

namespace ReportService.Persistence.Repositories.ReportRepository;

public class ReportReadRepository:ReadRepository<Report>,IReportReadRepository
{
    public ReportReadRepository(TDReportServiceContextDB context) : base(context)
    {
    }
}