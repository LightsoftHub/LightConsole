using Microsoft.Extensions.Configuration;

namespace ExampleConsole.Services
{
    public interface IConfigurationService
    {
        public string Env { get; }
        public string Description { get; }
    }

    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfiguration _configuration;

        public ConfigurationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Env => _configuration["AppConfigs:Environment"];

        public string Description => _configuration["AppConfigs:Description"];
    }
}
