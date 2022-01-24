using Microsoft.EntityFrameworkCore;
using PROJECT_NAME.Infrastructure;
using System;

namespace WebApi.EndToEndTests
{
    /// <summary>
    /// 
    /// </summary>
    public class DataBaseFixture : IDisposable
    {
        private bool _isDisposed;

        public CleanArchitectureDbContext CleanArchitectureDbContext { get; set; }

        public DataBaseFixture()
        {
            var options = new DbContextOptionsBuilder<CleanArchitectureDbContext>()
                .UseInMemoryDatabase(databaseName: "inmemblogdb")
                .Options;

            CleanArchitectureDbContext = new CleanArchitectureDbContext(options);
            CleanArchitectureDbContext.Database.EnsureCreated();

        }

        public void Dispose()
        {
            CleanArchitectureDbContext?.Dispose();
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

        ~DataBaseFixture()
        {
            Dispose(false);
        }
    }
}
