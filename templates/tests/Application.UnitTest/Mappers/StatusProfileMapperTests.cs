using AutoMapper;
using FluentAssertions;
using PROJECT_NAME.Application.Dtos;
using PROJECT_NAME.Application.Mappers;
using PROJECT_NAME.Domain.Entities;
using System;
using Xunit;

namespace Application.UnitTest.Mappers
{
    public class StatusProfileMapperTests
    {
        public readonly IMapper _mapper;

        public StatusProfileMapperTests()
        {
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProfileMapper>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public void StatusMapper_FromStatusToStatusResponse_Success()
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

            // Act
            var statusResponse = _mapper.Map<StatusResponse>(status);

            // Assert
            statusResponse.Should().NotBeNull();
            statusResponse.AssemblyVersion.Should().Be(status.AssemblyVersion);
            statusResponse.OsVersion.Should().Be(status.OsVersion);
            statusResponse.Started.Should().Be(status.Started);
            statusResponse.ProcessorCount.Should().Be(status.ProcessorCount);
            statusResponse.ElapsedTime.Should().Be(status.ElapsedTime);
        }
    }
}
