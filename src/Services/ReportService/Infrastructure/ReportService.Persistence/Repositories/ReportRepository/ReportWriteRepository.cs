
using ReportService.Application.Repositories.ReportRepository;
using ReportService.Domain.Entities;
using ReportService.Persistence.Contexts;

namespace ReportService.Persistence.Repositories.ReportRepository;

public class ReportWriteRepository:WriteRepository<Report>,IReportWriteRepository
{
    public ReportWriteRepository(TDReportServiceContextDB context) : base(context)
    {
    }
}