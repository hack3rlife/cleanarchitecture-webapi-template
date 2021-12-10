using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PROJECT_NAME.Domain.Interfaces;
using PROJECT_NAME.Infrastructure.Repositories;

namespace PROJECT_NAME.Infrastructure
{
    public static class ServiceCollectionConfiguration
    {
        /// <summary>
        /// Register all your Interfaces and its implementations here
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns>A <see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IStatusRepository, StatusRepository>();

            services.AddDbContext<CleanArchitectureDbContext>(options =>
            {
                options.UseInMemoryDatabase(databaseName: "in-memory");
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();
            });

            return services;
        }
    }
}