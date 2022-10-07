using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReportService.Application.Abstractions.Services;
using ReportService.Application.Repositories;
using ReportService.Application.Repositories.ReportRepository;
using ReportService.Persistence;
using ReportService.Persistence.Contexts;
using ReportService.Persistence.Repositories;
using ReportService.Persistence.Repositories.ReportRepository;
using ReportService.Persistence.Services;

namespace ReportService.Persistence;

public static class ServiceRegistiretion
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<TDReportServiceContextDB>(options => options.UseNpgsql(Configuration.ConnectionString));


        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

        services.AddScoped<IReportReadRepository, ReportReadRepository>();
        services.AddScoped<IReportWriteRepository, ReportWriteRepository>();

        services.AddScoped<IReportService, ReportManager>();

    }
}
    