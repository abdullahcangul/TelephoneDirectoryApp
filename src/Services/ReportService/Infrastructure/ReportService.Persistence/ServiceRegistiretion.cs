using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReportService.Persistence;
using ReportService.Persistence.Contexts;

namespace PersonService.Persistence;

public static class ServiceRegistiretion
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<TDReportServiceContextDB>(options => options.UseNpgsql(Configuration.ConnectionString));



    }
}
    