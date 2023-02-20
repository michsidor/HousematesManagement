using FluentAssertions;
using HousemateManagement.Models.Assignments.Dto;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;


namespace HousemateManagement.Tests.ControllersTests
{
    public class AssignmentControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private HttpClient _httpClient;
        public AssignmentControllerTests(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Theory]
        [InlineData("/api/assignment/all/15525635-E62A-4317-8B14-8486687423E1")]
        [InlineData("/api/assignment/15525635-E62A-4317-8B14-8486687423E1")]
        public async void GETRequestEndpoint_WhenCalled_ShouldReturnSucces(string url)
        {
            var resposne = await _httpClient.GetAsync(url);

            resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("/api/assignment/all/07C3BA84-53A5-4133-BAB8-C3A400C53013")]
        [InlineData("/api/assignment/07C3BA84-53A5-4133-BAB8-C3A400C53013")]
        public async void GETRequestEndpoint_WhenCalled_ShouldReturnFailure(string url)
        {
            var resposne = await _httpClient.GetAsync(url);

            resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.InternalServerError);
        }

        [Fact]
        public async Task PUTRequestEndpoint_WhenCalled_ShouldReturnSucces()
        {
            var assignment = new AssignmentDto()
            {
                Title = "Test",
                Description = "Test",
                Comments = "Test"
            };

            var response = await _httpClient.PutAsJsonAsync($"/api/assignment/07C3BA84-53A5-4133-BAB8-C3A400C53013", assignment);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task PUTRequestEndpoint_WhenCalled_ShouldReturnFailure()
        {
            var assignment = new AssignmentDto()
            {
                Title = "Test",
                Description = "Test",
                Comments = "Test"
            };

            var resposne = await _httpClient.PutAsJsonAsync("/api/assignment/08C3BA84-53A5-4133-BAB8-C3A400C53013", assignment);

            resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.InternalServerError);
        }

        [Fact]
        public async void POSTRequestEndpoint_WhenCalled_ShouldReturnSucces()
        {
            var assignment = new AssignmentDto()
            {
                Id = Guid.Parse("3C53BE67-BE24-418E-B159-2FA1C1FDC83F"),
                Title = "Test",
                Description = "Test",
                Comments = "Test"
            };

            var resposne = await _httpClient.PostAsJsonAsync("/api/assignment", assignment);

            resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async void POSTRequestEndpoint_WhenCalled_ShouldReturnFailure()
        {
            var assignment = new AssignmentDto()
            {
                Id = Guid.Parse("3C53BE67-BE24-418E-B159-2FA1C1FDC83F"),
                Title = "Test",
                Description = "Test",
                Comments = "Test"
            };

            var resposne = await _httpClient.PostAsJsonAsync("/api/assignment", assignment);

            resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.InternalServerError);
        }

        [Theory]
        [InlineData("/api/assignment/D7807704-A01E-4A4A-A725-F7DBD49E2313")]
        public async void DELETERequestEndpoint_WhenCalled_ShouldReturnSucces(string url)
        {
            var resposne = await _httpClient.DeleteAsync(url);

            resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("/api/assignment/D7807704-A01E-4A4A-A725-F7DBD49E2313")]
        public async void DELETERequestEndpoint_WhenCalled_ShouldReturnFailure(string url)
        {
            var resposne = await _httpClient.DeleteAsync(url);

            resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.InternalServerError);
        }
    }
}