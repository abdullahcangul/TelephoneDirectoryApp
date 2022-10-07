using EventBus.Base;
using EventBus.Base.Abstraction;
using EventBus.Factory;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PersonService.Application.IntegrationEvents.EventHandlers;
using RabbitMQ.Client;

namespace PersonService.Application;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection collection)
    {
        collection.AddMediatR(typeof(ServiceRegistration));
        collection.AddAutoMapper(typeof(ServiceRegistration));
        collection.AddHttpClient();
        
        collection.AddSingleton<IEventBus>(p =>
        {
            EventBusConfig config = new()
            {
                ConnectionRetryCount = 5,
                EventNameSuffix = "IntegrationEvent",
                SubscriberClientAppName = "ReportService",
                EventBusType = EventBusType.RabbitMQ
            };

            return EventBusFactory.Create(config, p);
        });
        
        collection.AddTransient<ReportCreatedIntegrationEventHandler>();
    }
}