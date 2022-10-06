using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonService.Application.Abstractions.Services;
using PersonService.Application.Repositories;
using PersonService.Application.Repositories.ContactRepository;
using PersonService.Application.Repositories.PersonRepository;
using PersonService.Persistence.Contexts;
using PersonService.Persistence.Repositories;
using PersonService.Persistence.Repositories.ContactRepository;
using PersonService.Persistence.Repositories.PersonRepository;
using PersonService.Persistence.Services;

namespace PersonService.Persistence;

public static class ServiceRegistiretion
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<TDPersonServiceContextDB>(options => options.UseNpgsql(Configuration.ConnectionString));
        
        
        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

        services.AddScoped<IPersonReadRepository, PersonReadRepository>();
        services.AddScoped<IPersonWriteRepository,PersonWriteRepository>();
        
        services.AddScoped<IContactReadRepository, ContactReadRepository>();
        services.AddScoped<IContactWriteRepository,ContactWriteRepository>();

        services.AddScoped<IPersonService, PersonManager>();
        services.AddScoped<IContactService, ContactManager>();


    }
}
    