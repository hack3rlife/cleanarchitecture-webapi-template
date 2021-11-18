using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PROJECT_NAME.Domain.Interfaces;

namespace PROJECT_NAME.Application
{
    public static class ServiceCollectionConfiguration
    {
        /// <summary>
        /// Register all your interfaces and implementations here
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns>A <see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IStatusService, StatusService>();

            return services;
        }
    }
}