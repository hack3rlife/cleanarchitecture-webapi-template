using PROJECT_NAME.Domain.Entities;
using PROJECT_NAME.Infrastructure.Repositories;
using System;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace Infrastructure.IntegrationTests.Repositories
{
    [Collection("DatabaseCollectionFixture")]
    public class StatusRepositoryTests
    {
        private readonly StatusRepository _statusRepository;
        private readonly DatabaseFixture _fixture;

        public StatusRepositoryTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
            _statusRepository = new StatusRepository(_fixture.CleanArchitectureDbContext);
        }

        [Fact]
        public async Task StatusRepository_CheckStatus_Success()
        {
            // Arrange
            var started = DateTime.UtcNow.ToString("s");
            var server = "test-server";
            var osVersion = "test";
            var assemblyVersion = "1.0.0.0";

            await _fixture.CleanArchitectureDbContext.Status.AddAsync(
                new Status
                {
                    Started = started,
                    Server = server,
                    OsVersion = osVersion,
                    AssemblyVersion = assemblyVersion
                });

            await _fixture.CleanArchitectureDbContext.SaveChangesAsync();

            // Act
            var response = await _statusRepository.GetStatusAsync();

            // Assert
            response.Should().NotBeNull();
            response.Started.Should().Be(started);
            response.Server.Should().Be(server);
            response.OsVersion.Should().Be(osVersion);
            response.AssemblyVersion.Should().Be(assemblyVersion);
        }
    }
}
