using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PROJECT_NAME.Infrastructure
{
    public static class ServiceCollectionConfiguration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}