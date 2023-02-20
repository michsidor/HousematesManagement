using FluentAssertions;
using HousemateManagement.Models.Advertisements.Dto;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;


namespace HousemateManagement.Tests.ControllersTests
{
    public class AdvertisementControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private HttpClient _httpClient;
        public AdvertisementControllerTests(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Theory]
        [InlineData("/api/advertisement/all/15525635-E62A-4317-8B14-8486687423E1")]
        [InlineData("/api/advertisement/15525635-E62A-4317-8B14-8486687423E1")]

        public async void GETRequestEndpoint_WhenCalled_ShouldReturnSucces(string url)
        {
            var resposne = await _httpClient.GetAsync(url);

            resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("/api/advertisement/all/07C3BA84-53A5-4133-BAB8-C3A400C53013")]
        [InlineData("/api/advertisement/07C3BA84-53A5-4133-BAB8-C3A400C53013")]
        public async void GETRequestEndpoint_WhenCalled_ShouldReturnFailure(string url)
        {
            var resposne = await _httpClient.GetAsync(url);

            resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.InternalServerError);
        }

        [Fact]
        public async Task PUTRequestEndpoint_WhenCalled_ShouldReturnSucces()
        {
            var advertisement = new AdvertisementDto()
            {
                Title = "Test",
                Description = "Test",
                Comments = "Test"
            };

            var response = await _httpClient.PutAsJsonAsync($"/api/advertisement/07C3BA84-53A5-4133-BAB8-C3A400C53013", advertisement);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task PUTRequestEndpoint_WhenCalled_ShouldReturnFailure()
        {
            var advertisement = new AdvertisementDto()
            {
                Title = "Test",
                Description = "Test",
                Comments = "Test"
            };

            var resposne = await _httpClient.PutAsJsonAsync("/api/advertisement/08C3BA84-53A5-4133-BAB8-C3A400C53013", advertisement);

            resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.InternalServerError);
        }

        [Fact]
        public async void POSTRequestEndpoint_WhenCalled_ShouldReturnSucces()
        {
            var advertisement = new AdvertisementDto()
            {
                Id = Guid.Parse("EDFA039D-E7F8-4172-9CC0-6E5F2755BBC9"),
                Title = "Test",
                Description = "Test",
                Comments = "Test"
            };

            var resposne = await _httpClient.PostAsJsonAsync("/api/advertisement", advertisement);

            resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async void POSTRequestEndpoint_WhenCalled_ShouldReturnFailure()
        {
            var advertisement = new AdvertisementDto()
            {
                Id = Guid.Parse("EDFA039U-E7F8-4172-9CC0-6E5F2755BBC9"),
                Title = "Test",
                Description = "Test",
                Comments = "Test"
            };

            var resposne = await _httpClient.PostAsJsonAsync("/api/advertisement", advertisement);

            resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.InternalServerError);
        }

        [Theory]
        [InlineData("/api/advertisement/EDFA039D-E7F8-4172-9CC0-6E5F2755BBC9")]
        public async void DELETERequestEndpoint_WhenCalled_ShouldReturnSucces(string url)
        {

            var resposne = await _httpClient.DeleteAsync(url);

            resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("/api/advertisement/EDFA039D-E7F8-4172-9CC0-6E5F2755BBC9")]
        public async void DELETERequestEndpoint_WhenCalled_ShouldReturnFailure(string url)
        {
            var resposne = await _httpClient.DeleteAsync(url);

            resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.InternalServerError);
        }
    }
}