using Microsoft.Extensions.Configuration;

namespace ZordConsole.Services
{
    public interface IConfigurationService
    {
        public string? Env { get; }
        public string? Description { get; }
    }

    public class ConfigurationService(IConfiguration _configuration) : IConfigurationService
    {
        public string? Env => _configuration["AppConfigs:Environment"];

        public string? Description => _configuration["AppConfigs:Description"];
    }
}
