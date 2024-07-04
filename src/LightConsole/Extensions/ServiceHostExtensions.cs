using LightConsole.Abstracts;
using Microsoft.Extensions.DependencyInjection;

namespace LightConsole.Extensions
{
    public static class ServiceHostExtensions
    {
        //here auto register DI implement from IService
        public static void AutoAddServices(this IServiceCollection services)
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
                    services.AddScoped(type.InterfaceService, type.Implementation);
                }
                else
                {
                    if (!type.Implementation.IsInterface)
                    {
                        services.AddScoped(type.Implementation);
                    }
                }
            }
        }
    }
}
