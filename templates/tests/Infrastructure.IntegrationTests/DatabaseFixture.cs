using Microsoft.EntityFrameworkCore;
using PROJECT_NAME.Infrastructure;
using System;

namespace Infrastructure.IntegrationTests
{
    public class DatabaseFixture: IDisposable
    {
        private bool _isDisposed;
        //public readonly IConfiguration Configuration;

        public CleanArchitectureDbContext CleanArchitectureDbContext { get; set; }

        public DatabaseFixture()
        {
            //    Configuration = new ConfigurationBuilder()
            //        .AddJsonFile("appsettings.json")
            //        .Build();

            //var connectionString = Configuration.GetConnectionString("CleanArchitectureConnectionString");

            var options = new DbContextOptionsBuilder<CleanArchitectureDbContext>()
                .UseInMemoryDatabase("in-memory")
                //.UseSqlServer(connectionString)
                .Options;

            CleanArchitectureDbContext = new CleanArchitectureDbContext(options);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
                return;


            if (disposing)
            {
                CleanArchitectureDbContext.Dispose();
            }

            _isDisposed = true;
        }

        ~DatabaseFixture()
        {
            Dispose(false);
        }
    }
}
