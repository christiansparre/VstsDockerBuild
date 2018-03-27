using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace VstsDockerBuild.IntegrationTests
{
    public class WebAppIntegrationTests
    {
        [Fact]
        public async Task ItWorks()
        {
            var client = new HttpClient();

            var webAppUrl = Environment.GetEnvironmentVariable("WebApp");

            var r = await client.GetAsync($"{webAppUrl}/status");

            Assert.Equal(HttpStatusCode.OK, r.StatusCode);

            var s = await r.Content.ReadAsStringAsync();

            Assert.Equal("All is right in the world", s);
        }
    }
}