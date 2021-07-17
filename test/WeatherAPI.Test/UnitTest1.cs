using System;
using Xunit;
using WeatherAPI.Controllers;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;

namespace WeatherAPI.Test
{

    [Collection("Integration Tests")]
    public class DefaultControllerTests
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public DefaultControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetRoot_ReturnsSuccessAndStatusUp()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.NotNull(response.Content);
            var responseObject = JsonSerializer.Deserialize<ResponseType>(
                await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            Assert.Equal("Up", responseObject?.Status);
        }

        private class ResponseType
        {
            public string Status { get; set; }
        }
    }

    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }
    }
}
