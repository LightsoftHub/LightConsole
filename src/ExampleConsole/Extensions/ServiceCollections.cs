using ExampleConsole.Abstracts;
using ExampleConsole.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace ExampleConsole.Extensions
{
    public static class ServiceCollections
    {
        //
        //  Summary:
        //      Register DI when run console.
        public static IServiceCollection AddServiceCollections(this IServiceCollection services, IConfiguration configuration)
        {
            //inject services here...
            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<IConfigurationService, ConfigurationService>();

            //inject features
            services.AddServices();

            return services;
        }

        //here auto register DI implement from IService
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            var iService = typeof(IService);

            var types = iService
                .Assembly
                .GetExportedTypes()
                .Where(t => iService.IsAssignableFrom(t) && t.Name != iService.Name) //select services implement from IService
                .Select(t => new
                {
                    InterfaceService = t.GetInterface($"I{t.Name}"),
                    Service = t.Name,
                    Implementation = t
                })
                .Where(t => t.Service != null);

            foreach (var type in types)
            {
                if (type.InterfaceService != null)
                {
                    services.AddTransient(type.InterfaceService, type.Implementation);
                }
                else
                {
                    if (!type.Implementation.IsInterface)
                    {
                        services.AddTransient(type.Implementation);
                    }
                }
            }

            return services;
        }
    }
}
