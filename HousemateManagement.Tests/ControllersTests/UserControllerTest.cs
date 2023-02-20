using Entity.Enums;
using FluentAssertions;
using HousemateManagement.Models.Assignments.Dto;
using HousemateManagement.Models.User.Dto;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;

namespace HousemateManagement.Tests.ControllersTests
{
    public class UserControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private HttpClient _httpClient;
        public UserControllerTest(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task PUTRequestEndpoint_WhenCalled_ShouldReturnSucces()
        {
            var user = new UserDto()
            {
                Name = "Test",
                SecondName = "Test",
                Login = "Test",
                Email = "Test",
                Password = "Test",
                Birthday = DateTime.Now,
                Gender = Gender.Man
            };

            var resposne = await _httpClient.PutAsJsonAsync("/api/user", user);

            resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async void POSTRequestQuitEndpoint_WhenCalled_ShouldReturnSucces()
        {
            var resposne = await _httpClient.PostAsync("/api/user/07C3BA84-53A5-4133-BAB8-C3A400C53013", null);

            resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async void POSTRequestQuitEndpoint_WhenCalled_ShouldReturnFailure()
        {
            var resposne = await _httpClient.PostAsync("/api/user/07C4BA84-53A5-4133-BAB8-C3A400C53013", null);

            resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.InternalServerError);
        }

        [Fact]
        public async void POSTRequestLoginEndpoint_WhenCalled_ShouldReturnSucces()
        {
            var user = new LoginUserDto()
            {
                Login = "fff",
                Password = "fff"
            };

            var resposne = await _httpClient.PostAsJsonAsync("/api/user", user);

            resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async void POSTRequestLoginEndpoint_WhenCalled_ShouldReturnFailure()
        {
            var user = new LoginUserDto()
            {
                Login = "fffWrong",
                Password = "fffWrong"
            };

            var resposne = await _httpClient.PostAsJsonAsync("/api/user", user);

            resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.InternalServerError);
        }
    }
}
