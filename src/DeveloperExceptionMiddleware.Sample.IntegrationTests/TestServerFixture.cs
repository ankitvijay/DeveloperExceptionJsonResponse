using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DeveloperExceptionMiddlewareExtensions.Sample;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace DeveloperExceptionMiddleware.Sample.IntegrationTests
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
