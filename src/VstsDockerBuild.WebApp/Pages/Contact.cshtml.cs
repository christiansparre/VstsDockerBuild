using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace VstsDockerBuild.WebApp.Pages
{
    public class ContactModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _client;

        public ContactModel(IConfiguration configuration, HttpClient client)
        {
            _configuration = configuration;
            _client = client;
        }

        public string Message { get; set; }

        public async Task OnGet()
        {
            var r = await _client.GetStringAsync(_configuration["PongService"]);

            Message = $"My Ping! Your {r}";
        }
    }
}
