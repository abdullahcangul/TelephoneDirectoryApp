using BasketService.Api.Extensions;
using EventBus.Base.Abstraction;
using FluentValidation.AspNetCore;
using PersonService.Application;
using PersonService.Application.IntegrationEvents.EventHandlers;
using PersonService.Application.IntegrationEvents.Events;
using ReportService.Infrastructure.Filters;
using ReportService.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices();
// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation()
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureConsul(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.RegisterWithConsul(app.Lifetime);

var eventBus = app.Services.GetRequiredService<IEventBus>();

eventBus.Subscribe<ReportCreatedIntegrationEvent, ReportCreatedIntegrationEventHandler>(); 

app.Run();