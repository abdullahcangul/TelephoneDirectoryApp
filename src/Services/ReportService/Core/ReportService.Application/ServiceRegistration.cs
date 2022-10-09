using System.Reflection;
using EventBus.Base;
using EventBus.Base.Abstraction;
using EventBus.Factory;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PersonService.Application.Features.Commands.ReportCommand.CreateReport;
using PersonService.Application.IntegrationEvents.EventHandlers;
using RabbitMQ.Client;

namespace PersonService.Application;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection collection)
    {
        
        collection.AddMediatR(Assembly.GetExecutingAssembly());
        collection.AddAutoMapper(typeof(ServiceRegistration));
        collection.AddHttpClient();
        
        collection.AddSingleton<IEventBus>(p =>
        {
            EventBusConfig config = new()
            {
                ConnectionRetryCount = 5,
                EventNameSuffix = "IntegrationEvent",
                SubscriberClientAppName = "ReportService",
                EventBusType = EventBusType.RabbitMQ,
                Connection = new ConnectionFactory()
                {
                    HostName = "c_rabbitmq"
                }
            };

            return EventBusFactory.Create(config, p);
        });
        
        collection.AddTransient<ReportCreatedIntegrationEventHandler>();
    }
}