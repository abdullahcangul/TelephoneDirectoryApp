using ReportService.Application.Repositories;
using ReportService.Domain.Entities;

namespace ReportService.Persistence.Services;

public class ReportManager:BaseManager<Report>
{
    public ReportManager(IReadRepository<Report> readRepository, IWriteRepository<Report> writeRepository) : base(readRepository, writeRepository)
    {
    }
}