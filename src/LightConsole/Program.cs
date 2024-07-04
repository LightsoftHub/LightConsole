using LightConsole.Extensions;
using LightConsole.Features;
using Microsoft.Extensions.DependencyInjection;

// set Environment
//Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Live");

Console.WriteLine("Hello World, this is .NET 8 Console boilerplate with dependency injection");

using var host = Host.CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();
var serviceProvider = scope.ServiceProvider;

await serviceProvider.GetRequiredService<IViewDateTime>().Print();
await serviceProvider.GetRequiredService<ViewData>().Print();

Console.WriteLine($"Done.");
Console.ReadKey();
