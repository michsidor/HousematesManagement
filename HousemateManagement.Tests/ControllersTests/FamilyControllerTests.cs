using Entity.Entities;
using FluentAssertions;
using HousemateManagement.Models.Family.Dto;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;

namespace HousemateManagement.Tests.ControllersTests
{
    public class FamilyControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private HttpClient _httpClient;
        public FamilyControllerTests(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task PUTRequestEndpoint_WhenCalled_ShouldReturnSucces()
        {
            var family = new AddFamilyDto()
            {
                Name = "name",
            };

            var resposne = await _httpClient.PutAsJsonAsync("/api/family/07C3BA84-53A5-4133-BAB8-C3A400C53013", family);

            resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task PUTRequestEndpoint_WhenCalled_ShouldReturnFailure()
        {
            var family = new AddFamilyDto()
            {
                Name = "name",
            };

            var resposne = await _httpClient.PutAsJsonAsync("/api/family/08C3BA84-53A5-4133-BAB8-C3A400C53013", family);

            resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.InternalServerError);
        }

        [Fact]
        public async void POSTRequestQuitEndpoint_WhenCalled_ShouldReturnSucces()
        {
            var family = new FamilyDto()
            {
                Id = Guid.Parse("15525635-E62A-4317-8B14-8486687423E1"),
                Name = "Test",
            };

            var resposne = await _httpClient.PostAsJsonAsync("/api/family/07C3BA84-53A5-4133-BAB8-C3A400C53013", family);

            resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async void POSTRequestQuitEndpoint_WhenCalled_ShouldReturnFailure()
        {
            var family = new FamilyDto()
            {
                Id = Guid.NewGuid(),
                Name = "Test",
            };

            var resposne = await _httpClient.PostAsJsonAsync("/api/family/07C3BA84-53A5-4133-BAB8-C3A400C53013", family);

            resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.InternalServerError);
        }
    }
}
