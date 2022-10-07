using Microsoft.EntityFrameworkCore;
using ReportService.Application.Abstractions.Services;
using ReportService.Application.Repositories;
using ReportService.Application.Repositories.ReportRepository;
using ReportService.Application.Utility.Results;
using ReportService.Domain.Entities;

namespace ReportService.Persistence.Services;

public class ReportManager:BaseManager<Report>,IReportService
{
    private readonly IReportReadRepository _reportReadRepository;
    public ReportManager(IReadRepository<Report> readRepository, IWriteRepository<Report> writeRepository, IReportReadRepository reportReadRepository) : base(readRepository, writeRepository)
    {
        _reportReadRepository = reportReadRepository;
    }

    public async Task<IDataResult<List<Report>>> GetReportWithReportDetailAsync()
    {
        return new SuccessDataResult<List<Report>>(
            await _reportReadRepository
                .GetAll()
                .Include(r => r.ReportDetails)
                .ToListAsync()
        );
    }
}