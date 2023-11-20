using ZordConsole.Abstracts;
using ZordConsole.Services;

namespace ZordConsole.Features
{
    public class ViewData(IConfigurationService _configurationService) : IService
    {
        public Task Print()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            Console.WriteLine($"---------------");
            Console.WriteLine($"-- Read data from appsettings.{env}.json");
            Console.WriteLine($"App Env_: {_configurationService.Env}");
            Console.WriteLine($"App Description_: {_configurationService.Description}");

            return Task.CompletedTask;
        }
    }
}
