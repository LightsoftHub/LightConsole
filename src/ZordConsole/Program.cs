using Microsoft.Extensions.DependencyInjection;
using ZordConsole.Extensions;
using ZordConsole.Features;

// set Environment
//Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Live");

Console.WriteLine("Hello World, this is example for dependency injection in .NET 7 console");

using var host = Host.CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();
var serviceProvider = scope.ServiceProvider;

serviceProvider.GetRequiredService<IViewDateTime>().Print();
serviceProvider.GetRequiredService<ViewData>().Print();

Console.WriteLine($"Done.");
Console.ReadKey();
