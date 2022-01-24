using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using PROJECT_NAME.Application.Services;
using IStatusService = PROJECT_NAME.Application.Interfaces.IStatusService;

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
            // Automapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IStatusService, StatusService>();

            return services;
        }
    }
}