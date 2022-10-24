using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace PersonService.Persistence;

static class Configuration
{
    static public string ConnectionString
    {
        get
        {
            ConfigurationManager configurationManager = new();
          //  configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/PersonService.API"));
            configurationManager.SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
            configurationManager.AddJsonFile("appsettings.json");

            return configurationManager.GetConnectionString("PostgreSQL");
        }
    }
}