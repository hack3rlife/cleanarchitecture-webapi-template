using Microsoft.EntityFrameworkCore;
using PROJECT_NAME.Domain.Entities;
using PROJECT_NAME.Domain.Interfaces;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace PROJECT_NAME.Infrastructure.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly CleanArchitectureDbContext _cleanArchitectureDbContext;

        public StatusRepository(CleanArchitectureDbContext cleanArchitectureDbContext)
        {
            _cleanArchitectureDbContext = cleanArchitectureDbContext;
        }

        public async Task<Status> GetStatusAsync()
        {
            return await _cleanArchitectureDbContext.Status.FirstOrDefaultAsync();
        }

        public async Task UpsertStatusAsync()
        {
            await _cleanArchitectureDbContext.Status.AddAsync(
                        new Status
                        {
                            Started = DateTime.UtcNow.ToString("s"),
                            Server = Environment.MachineName,
                            OsVersion = Environment.OSVersion.ToString(),
                            AssemblyVersion = Assembly.GetExecutingAssembly().GetName().Version?.ToString(),
                            ProcessorCount = Environment.ProcessorCount
                        });

            await _cleanArchitectureDbContext.SaveChangesAsync();

        }
    }
}