using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


builder.Configuration.AddJsonFile("Configurations/ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration).AddConsul();

builder.Services.AddHttpClient("person", c =>
{
    c.BaseAddress = new Uri(builder.Configuration["urls:person"]);
});

builder.Services.AddHttpClient("report", c =>
{
    c.BaseAddress = new Uri(builder.Configuration["urls:report"]);
});

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
await app.UseOcelot();
app.Run();