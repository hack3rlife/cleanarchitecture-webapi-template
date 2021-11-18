using Microsoft.EntityFrameworkCore;
using PROJECT_NAME.Domain;
using PROJECT_NAME.Domain.Entities;

namespace PROJECT_NAME.Infrastructure
{
    public class CleanArchitectureDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public CleanArchitectureDbContext(DbContextOptions<CleanArchitectureDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Status> Status { get; set; }

    }
}
