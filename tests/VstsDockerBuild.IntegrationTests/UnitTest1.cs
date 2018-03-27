using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace VstsDockerBuild.IntegrationTests
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            var client = new HttpClient();

            var pongServiceUrl = Environment.GetEnvironmentVariable("PongService");


            var s = await client.GetStringAsync(pongServiceUrl);

            Assert.Equal("Pong!", s);
        }
    }
}
