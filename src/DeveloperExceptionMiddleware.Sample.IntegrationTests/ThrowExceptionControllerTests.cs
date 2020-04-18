using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Shouldly;
using Xunit;

namespace DeveloperExceptionMiddleware.Sample.IntegrationTests
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

            var result = await Deserialize<SuperSpecialException>(response);
            result.ShouldNotBeNull();
            result.ShouldBeOfType<SuperSpecialException>();
        }

        private static async Task<T> Deserialize<T>(HttpResponseMessage message)
        {
            await using var stream = await message.Content.ReadAsStreamAsync();
            var serializer = new JsonSerializer();

            using var sr = new StreamReader(stream);
            using var jsonTextReader = new JsonTextReader(sr);
            return serializer.Deserialize<T>(jsonTextReader);
        }
    }
}
