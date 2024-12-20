﻿using LightConsole.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LightConsole.Extensions
{
    public static class ServiceCollections
    {
        /// <summary>
        ///     Register DI when run console.
        /// </summary>
        public static IServiceCollection AddServiceCollections(this IServiceCollection services, IConfiguration config)
        {
            // manual inject services here
            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<IConfigurationService, ConfigurationService>();

            // auto inject services
            services.AutoAddServices();

            return services;
        }
    }
}
