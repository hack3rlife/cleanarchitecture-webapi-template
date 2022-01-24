using FluentAssertions;
using Newtonsoft.Json;
using PROJECT_NAME.Domain.Entities;
using PROJECT_NAME.WebApi;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace WebApi.EndToEndTests.Controllers
{
    [Collection("DatabaseCollectionFixture")]
    public class StatusServiceTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;
        private readonly HttpClient _client;

        public StatusServiceTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();

        }

        [Fact(DisplayName = "Check_ServiceStatus_Success")]
        public async Task Check_ServiceStatus_Success()
        {
            // Arrange
            var path = "/api/status/";

            // Act
            var responseMessage = await _client.GetAsync(path);
            var content = await responseMessage.Content.ReadAsStringAsync();

            var status = JsonConvert.DeserializeObject<Status>(content);

            // Assert
            status.Should().BeOfType<Status>();
            responseMessage.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
