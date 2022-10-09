using PersonService.Api.Extensions;
using EventBus.Base.Abstraction;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using PersonService.Api.Extensions;
using PersonService.Application;
using PersonService.Application.Features.Commands.CreatePerson;
using PersonService.Application.IntegrationEvents.EventHandlers;
using PersonService.Application.IntegrationEvents.Events;
using PersonService.Infrastructure.Filters;
using PersonService.Persistence;
using PersonService.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices();

builder.Configuration.AddEnvironmentVariables();
builder.Services.ConfigureConsul(builder.Configuration);

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreatePersonValidators>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

//builder.Services.ConfigureConsul(builder.Configuration.AddEnvironmentVariables().Build());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.WebHost.UseDefaultServiceProvider((context, options) =>
{
    options.ValidateOnBuild = false;
    options.ValidateScopes = false;
});
builder.WebHost.UseDefaultServiceProvider(options => options.ValidateScopes = false);
//builder.Configuration.AddEnvironmentVariables();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();



app.MapControllers();

app.RegisterWithConsul(app.Lifetime,app.Configuration);

var eventBus = app.Services.GetRequiredService<IEventBus>();

eventBus.Subscribe<ReportCreateIntegrationEvent, ReportCreateIntegrationEventHandler>(); 
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TDPersonServiceContextDB>();
    db.Database.Migrate();
}
app.Run();

