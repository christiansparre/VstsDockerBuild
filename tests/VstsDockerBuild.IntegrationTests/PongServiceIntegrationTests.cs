using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Xunit;

namespace VstsDockerBuild.IntegrationTests
{
    public class PongServiceIntegrationTests
    {
        [Fact]
        public async Task ItReturnsPong()
        {
            var client = new HttpClient();

            var pongServiceUrl = Environment.GetEnvironmentVariable("PongService");

            var s = await client.GetStringAsync(pongServiceUrl);

            Assert.Equal("Pong!", s);
        }

        [Fact]
        public async Task ItWritesEventToMongoDB()
        {
            var client = new HttpClient();

            var pongServiceUrl = Environment.GetEnvironmentVariable("PongService");
            var mongodbConnectionString = Environment.GetEnvironmentVariable("MongoDB");

            var req = new HttpRequestMessage(HttpMethod.Get, pongServiceUrl);
            req.Headers.Add("X-Bacon", "Yes please!");

            var resp = await client.SendAsync(req);

            Assert.Equal(HttpStatusCode.OK, resp.StatusCode);

            var mongoUrl = new MongoUrl(mongodbConnectionString);
            var collection = new MongoClient(mongoUrl).GetDatabase(mongoUrl.DatabaseName).GetCollection<BsonDocument>("ping-events");

            var document = await collection.Find(new BsonDocument { ["Headers.X-Bacon"] = "Yes please!" }).FirstOrDefaultAsync();

            Assert.NotNull(document);
        }
    }
}
