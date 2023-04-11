using ExampleConsole.Extensions;
using ExampleConsole.Features;
using System;
using System.Threading.Tasks;

namespace ExampleConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //set .json environment
            //Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Live");

            Console.WriteLine("Hello World, this is example for dependency injection in .NET 5 console");

            var host = HostBuilderExtensions.CreateHostBuilder(args).Build();

            await host.Instance<IViewDateTime>().Print();
            await host.Instance<ViewData>().Print();

            Console.WriteLine($"Done.");

            await Task.Delay(5000);
        }
    }
}
