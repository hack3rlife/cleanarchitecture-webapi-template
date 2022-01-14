using PROJECT_NAME.Domain.Entities;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PROJECT_NAME.Infrastructure
{
    public class DbContextDataSeed
    {
        public static async Task SeedSampleDataAsync(CleanArchitectureDbContext context)
        {
            if (!context.Status.Any())
            {
                await context.Status.AddAsync(
                    new Status
                    {
                        Started = DateTime.UtcNow,
                        Server = Environment.MachineName,
                        OsVersion = Environment.OSVersion.ToString(),
                        AssemblyVersion = Assembly.GetEntryAssembly().GetName().Version.ToString(),
                    });

                await context.SaveChangesAsync();
            }
        }

        public static void SeedSampleData(CleanArchitectureDbContext context)
        {
            if (!context.Status.Any())
            {
                context.Status.Add(
                    new Status
                    {
                        Started = DateTime.UtcNow,
                        Server = Environment.MachineName,
                        OsVersion = Environment.OSVersion.ToString(),
                        AssemblyVersion = Assembly.GetEntryAssembly().GetName().Version.ToString(),
                    });

                context.SaveChanges();
            }
        }
    }
}