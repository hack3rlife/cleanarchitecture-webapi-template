using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PROJECT_NAME.Infrastructure;
using System.Linq;

namespace WebApi.EndToEndTests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder            
                 .ConfigureServices(services =>
                 {
                     var descriptor = services.FirstOrDefault(d => d.ServiceType == typeof(DbContextOptions<CleanArchitectureDbContext>));

                     services.Remove(descriptor);

                 })
                 .ConfigureTestServices(testServices =>
                 {
                     testServices.AddDbContext<CleanArchitectureDbContext>(options =>
                     {
                         options.UseInMemoryDatabase("inmemblogdb");
                         options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                         options.EnableSensitiveDataLogging();
                         options.EnableDetailedErrors();
                     });
                 });
        }
    }
}