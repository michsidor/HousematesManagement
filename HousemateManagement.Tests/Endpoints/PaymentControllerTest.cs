using FluentAssertions;
using HousemateManagement.Models.Payments.Commands;
using HousemateManagement.Models.Payments.Dto;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Text;
using System.Text.Json;

namespace HousemateManagement.Tests.Endpoints
{
    public class PaymentControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private HttpClient _httpClient;
        public PaymentControllerTest(WebApplicationFactory<Program> factory)
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
        public async void DELETEEndpoint_WhenCalled_ShouldReturnSucces()
        {

            var resposne = await _httpClient.DeleteAsync("/api/payment/47A99A11-F167-419F-9C67-4908A34CC013");

            resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async void DELETEEndpoint_WhenCalled_ShouldReturnFailure()
        {
            var resposne = await _httpClient.DeleteAsync("/api/payment/07C3BA84-53A5-4133-BAB8-C3A400C53013");

            resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.InternalServerError);
        }

        [Fact]
        public async void PUTEndpoint_WhenCalled_ShouldReturnSucces()
        {
            var body = new PaymentDto()
            {
                Amount = 1,
                Deadline = DateTime.Now,
                DebtorsMetadata = "Metadata"
            };

            var body2 = new AddPaymentCommand()
            {
                PaymentDto = body,
                UserId = Guid.Parse("15525635-E62A-4317-8B14-8486687423E1")
            };

            var content = new StringContent(JsonSerializer.Serialize(body2), UnicodeEncoding.UTF8, "application/json");

            var resposne = await _httpClient.PutAsync("/api/payment/47A99A11-F167-419F-9C67-4908A34CC013", content);

            resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //[Fact]
        //public async void PUTEndpoint_WhenCalled_ShouldReturnFailure()
        //{
        //    var resposne = await _httpClient.PutAsync("/api/payment/07C3BA84-53A5-4133-BAB8-C3A400C53013");

        //    resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.InternalServerError);
        //}

        //[Fact]
        //public async void POSTEndpoint_WhenCalled_ShouldReturnSucces()
        //{

        //    var resposne = await _httpClient.PostAsync("/api/payment/47A99A11-F167-419F-9C67-4908A34CC013");

        //    resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        //}

        //[Fact]
        //public async void POSTEndpoint_WhenCalled_ShouldReturnFailure()
        //{
        //    var resposne = await _httpClient.PostAsync("/api/payment/07C3BA84-53A5-4133-BAB8-C3A400C53013");

        //    resposne.StatusCode.Should().Be(System.Net.HttpStatusCode.InternalServerError);
        //}
    }
}