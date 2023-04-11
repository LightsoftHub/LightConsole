using ExampleConsole.Abstracts;
using ExampleConsole.Services;
using System;
using System.Threading.Tasks;

namespace ExampleConsole.Features
{
    public class ViewData : IService
    {
        private readonly IConfigurationService _configurationService;

        public ViewData(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

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
