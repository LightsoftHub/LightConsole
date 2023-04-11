// See https://aka.ms/new-console-template for more information
using ExampleConsole.Extensions;
using ExampleConsole.Features;

//set .json environment
//Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Live");

Console.WriteLine("Hello World, this is example for dependency injection in .NET 6 console");

var host = HostBuilderExtensions.CreateHostBuilder(args).Build();

await host.Instance<IViewDateTime>().Print();
await host.Instance<ViewData>().Print();

Console.WriteLine($"Done.");

await Task.Delay(5000);
