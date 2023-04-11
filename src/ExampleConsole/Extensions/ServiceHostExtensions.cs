using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ExampleConsole.Extensions
{
    public static class ServiceHostExtensions
    {
        public static T Instance<T>(this IHost host)
        {
            return host.Services.GetRequiredService<T>();
        }
    }
}
