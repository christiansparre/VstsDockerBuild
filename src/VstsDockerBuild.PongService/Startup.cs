using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using VstsDockerBuild.PongService.Models;

namespace VstsDockerBuild.PongService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(s =>
            {
                var url = new MongoUrl(Configuration.GetConnectionString("MongoDB"));
                return new MongoClient(url).GetDatabase(url.DatabaseName);
            });

            services.AddTransient(s => s.GetService<IMongoDatabase>().GetCollection<PingRegisteredEvent>("ping-events"));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Pong!");

                var coll = context.RequestServices.GetService<IMongoCollection<PingRegisteredEvent>>();

                await coll.InsertOneAsync(new PingRegisteredEvent { RegisteredAt = DateTime.UtcNow, Headers = context.Request.Headers.ToDictionary(d => d.Key, d => d.Value.ToArray()) });
            });
        }
    }
}
