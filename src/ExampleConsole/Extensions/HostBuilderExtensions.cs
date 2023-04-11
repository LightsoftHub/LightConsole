using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace ExampleConsole.Extensions
{
    public static class HostBuilderExtensions
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder().SetConfiguration().Build();

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.SetConfiguration();
                })
                .ConfigureServices(services =>
                {
                    //inject services here...
                    services.AddServiceCollections(Configuration);
                });
        }

        public static IConfigurationBuilder SetConfiguration(this IConfigurationBuilder configurationbuilder)
        {
            configurationbuilder
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Staging"}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            return configurationbuilder;
        }
    }
}
