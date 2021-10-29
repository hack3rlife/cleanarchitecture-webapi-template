using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PROJECT_NAME.Application
{
    public static class ServiceCollectionConfiguration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}