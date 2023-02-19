using FluentAssertions;
using HousemateManagement.Models.Payments.Dto;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;


namespace HousemateManagement.Tests.Endpoints.ControllersTests
{
    public class PaymentControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private HttpClient _httpClient;
        public PaymentControllerTests(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Theory]
        [InlineData("/api/payment/all/15525635-E62A-4317-8B14-8486687423E1")]
        [InlineData("/api/payment/15525635-E62A-4317-8B14-8486687423E1")]
        public async void GETRequestEndpoint_WhenCalled_ShouldReturnSucces(string url)
        {
            var resposne = await _httpClient.GetAsync(url);

            resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("/api/payment/all/07C3BA84-53A5-4133-BAB8-C3A400C53013")]
        [InlineData("/api/payment/07C3BA84-53A5-4133-BAB8-C3A400C53013")]
        public async void GETRequestEndpoint_WhenCalled_ShouldReturnFailure(string url)
        {
            var resposne = await _httpClient.GetAsync(url);

            resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.InternalServerError);
        }

        [Fact]
        public async Task PUTRequestEndpoint_WhenCalled_ShouldReturnSucces()
        {
            var payment = new PaymentDto()
            {
                Amount = 1,
                Deadline = DateTime.Now,
                DebtorsMetadata = "Metadata"
            };

            var response = await _httpClient.PutAsJsonAsync($"/api/payment/07C3BA84-53A5-4133-BAB8-C3A400C53013", payment);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task PUTRequestEndpoint_WhenCalled_ShouldReturnFailure()
        {
            var payment = new PaymentDto()
            {
                Amount = 1,
                Deadline = DateTime.Now,
                DebtorsMetadata = "Metadata"
            };

            var resposne = await _httpClient.PutAsJsonAsync("/api/payment/08C3BA84-53A5-4133-BAB8-C3A400C53013", payment);

            resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.InternalServerError);
        }

        [Fact]
        public async void POSTRequestEndpoint_WhenCalled_ShouldReturnSucces()
        {
            var payment = new PaymentDto()
            {
                Id = Guid.Parse("4344A535-E4F4-47A7-B9C0-63CC387D8FE1"),
                Amount = 1,
                Deadline = DateTime.Now,
                DebtorsMetadata = "Metadata"
            };

            var resposne = await _httpClient.PostAsJsonAsync("/api/payment", payment);

            resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async void POSTRequestEndpoint_WhenCalled_ShouldReturnFailure()
        {
            var payment = new PaymentDto()
            {
                Id = Guid.Parse("08C3BA84-53A5-4133-BAB8-C3A400C53013"),
                Amount = 1,
                Deadline = DateTime.Now,
                DebtorsMetadata = "Metadata"
            };

            var resposne = await _httpClient.PostAsJsonAsync("/api/payment", payment);

            resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.InternalServerError);
        }

        [Theory]
        [InlineData("/api/payment/all/67530651-C378-431C-91F8-D5706891F287")]
        public async void DELETERequestEndpoint_WhenCalled_ShouldReturnSucces(string url)
        {
            var resposne = await _httpClient.DeleteAsync(url);

            resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("/api/payment/all/68530651-C378-431C-91F8-D5706891F287")]
        public async void DELETERequestEndpoint_WhenCalled_ShouldReturnFailure(string url)
        {
            var resposne = await _httpClient.DeleteAsync(url);

            resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.InternalServerError);
        }
    }
}