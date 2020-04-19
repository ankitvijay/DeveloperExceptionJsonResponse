using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace DeveloperExceptionJsonResponse.Sample.IntegrationTests
{
    public class ThrowExceptionControllerTests : IClassFixture<TestServerFixture>
    {
        private readonly TestServerFixture _testServerFixture;

        public ThrowExceptionControllerTests(TestServerFixture testServerFixture)
        {
            _testServerFixture = testServerFixture;
        }

        [Fact]
        public async Task ItShouldThrowSuperSpecialException()
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod("GET"), "/throwexception");

            // Act
            var response = await _testServerFixture.Client.SendAsync(request);

            // Assert
            response.StatusCode.ShouldBe(HttpStatusCode.InternalServerError);
            response.Content.Headers.ContentType.MediaType.ShouldBe("application/json");

            var result = await Deserialize<Error>(response);
            
            result.ShouldNotBeNull();
            result.ExceptionType.ShouldBe(typeof(SuperSpecialException).ToString());
            result.StackTrace.ShouldNotBeNull();
            result.Message.ShouldNotBeNull();
            
            result.Data.ShouldNotBeNull();
            result.Data.Count.ShouldBe(3);
            result.Data.ShouldContainKey("AdditionalInfo");
            result.Data.ShouldContainKey("ErrorCode");
            result.Data.ShouldContainKey("TimeStamp");
        }

        private static async Task<T> Deserialize<T>(HttpResponseMessage message)
        {
            var jsonString = await message.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(jsonString);
        }
    }
}
