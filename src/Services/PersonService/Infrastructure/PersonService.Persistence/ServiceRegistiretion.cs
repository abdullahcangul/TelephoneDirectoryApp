using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonService.Persistence.Contexts;

namespace PersonService.Persistence;

public static class ServiceRegistiretion
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<TDPersonServiceContextDB>(options => options.UseNpgsql(Configuration.ConnectionString));
    }
}
    