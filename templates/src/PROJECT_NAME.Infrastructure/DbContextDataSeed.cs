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
                        Started = DateTime.UtcNow.ToString("s"),
                        Server = Environment.MachineName,
                        OsVersion = Environment.OSVersion.ToString(),
                        AssemblyVersion = Assembly.GetEntryAssembly().GetName().Version.ToString(),
                        ProcessorCount = Environment.ProcessorCount
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
                        Started = DateTime.UtcNow.ToString("s"),
                        Server = Environment.MachineName,
                        OsVersion = Environment.OSVersion.ToString(),
                        AssemblyVersion = Assembly.GetEntryAssembly().GetName().Version.ToString(),
                        ProcessorCount = Environment.ProcessorCount
                    });

                context.SaveChanges();
            }
        }
    }
}