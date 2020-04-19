using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;

namespace DeveloperExceptionJsonResponse.Sample.IntegrationTests
{
    public class TestServerFixture : WebApplicationFactory<Program>
    {
        public HttpClient Client { get; private set; }

        public TestServerFixture()
        {
            Client = CreateClient();
        }
    }
}
