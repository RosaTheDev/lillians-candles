using System.Net;
using System.Threading.Tasks;
using RestSharp;
using Xunit;
using FluentAssertions;
using Allure.Xunit.Attributes;
using Allure.Xunit.Attributes.Steps;
using Allure.Net.Commons;

namespace LilliansCandles.Tests
{
    [AllureParentSuite("Lillian's Candles API Testing")]
    [Collection("Allure API Test Collection")]
    public class ApiTests
    {
        private readonly RestClient _client = new RestClient("http://localhost:5124/api");

        [Trait("API", "Candles")]
        [Trait("Endpoint", "Get All Candles")]
        [Fact(DisplayName = "GET /api/candles returns HTTP status code 200")]
        [AllureFeature("Get All Candles")]
        [AllureDescription(@"
        Given candle details are available
        When attempting to perform a GET request to retrieve all candles
        Then the response should not be null and the status code should be 200.")]
        public async Task Get_Candles_ShouldReturn200()
        {
            // Arrange
            AllureApi.Step("Given candle details are available");

            // Act
            RestRequest request = new RestRequest("/candles", Method.Get);
            RestResponse response = null;

            await AllureApi.Step("When performing a GET request to retrieve all candles", async () =>
            {
                response = await _client.ExecuteAsync(request);
                Console.WriteLine($"StatusCode: {response.StatusCode}");
                Console.WriteLine($"Response Content: {response.Content}");
            });

            // Assert
            AllureApi.Step("Then the response should not be null and the status code should be 200", () =>
            {
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                response.Content.Should().NotBeNull();
            });
        }
    }
}