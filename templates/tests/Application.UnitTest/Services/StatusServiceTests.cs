using AutoMapper;
using FluentAssertions;
using Moq;
using PROJECT_NAME.Application.Interfaces;
using PROJECT_NAME.Application.Mappers;
using PROJECT_NAME.Application.Services;
using PROJECT_NAME.Domain.Entities;
using PROJECT_NAME.Domain.Interfaces;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTest.Services
{
    public class StatusServiceTests
    {
        private readonly Mock<IStatusRepository> _mockStatusRepository;
        private readonly IStatusService _statusService;

        public StatusServiceTests()
        {
            var configurationProvider = new MapperConfiguration(cfg => { cfg.AddProfile<ProfileMapper>(); });

            var mapper = configurationProvider.CreateMapper();

            _mockStatusRepository = new Mock<IStatusRepository>();
            _statusService = new StatusService(_mockStatusRepository.Object, mapper);
        }

        [Fact]
        public async Task StatusService_CheckStatus_Success()
        {
            // Arrange
            var status = new Status
            {
                AssemblyVersion = "TheAssemblyVersion",
                OsVersion = "OsVersion",
                Server = "TheServerName",
                Started = DateTime.UtcNow.ToString("s"),
                ProcessorCount = 1,
                ElapsedTime = DateTime.UtcNow.AddDays(1).ToString("s"),
            };

            _mockStatusRepository
                .Setup(x => x.GetStatusAsync())
                .ReturnsAsync(status)
                .Verifiable();

            // Act
            var statusResponse = await _statusService.GetStatusAsync();

            // Arrange
            statusResponse.Should().NotBeNull();
            _mockStatusRepository.Verify(x => x.GetStatusAsync(), Times.Once());

        }
    }
}
