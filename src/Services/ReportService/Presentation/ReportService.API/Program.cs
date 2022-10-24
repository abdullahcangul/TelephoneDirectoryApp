
using EventBus.Base.Abstraction;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using PersonService.Api.Extensions;
using PersonService.Application;
using PersonService.Application.IntegrationEvents.EventHandlers;
using PersonService.Application.IntegrationEvents.Events;
using ReportService.Infrastructure.Filters;
using ReportService.Persistence;
using ReportService.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();
builder.Configuration.AddEnvironmentVariables();
builder.Services.ConfigureConsul(builder.Configuration);
// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation()
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.ConfigureConsul(builder.Configuration.AddEnvironmentVariables().Build());

builder.WebHost.UseDefaultServiceProvider((context, options) =>
{
    options.ValidateOnBuild = false;
    options.ValidateScopes = false;
});
//builder.Configuration.AddEnvironmentVariables();
builder.WebHost.UseDefaultServiceProvider(options => options.ValidateScopes = false);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.RegisterWithConsul(app.Lifetime,app.Configuration);

var eventBus = app.Services.GetRequiredService<IEventBus>();

eventBus.Subscribe<ReportCreatedIntegrationEvent, ReportCreatedIntegrationEventHandler>(); 
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TDReportServiceContextDB>();
    db.Database.Migrate();
}
app.Run();