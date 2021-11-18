using Microsoft.EntityFrameworkCore;
using PROJECT_NAME.Domain;
using PROJECT_NAME.Domain.Interfaces;
using System.Threading.Tasks;
using PROJECT_NAME.Domain.Entities;

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
    }
}