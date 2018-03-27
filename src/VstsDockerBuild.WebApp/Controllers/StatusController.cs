using Microsoft.AspNetCore.Mvc;

namespace VstsDockerBuild.WebApp.Controllers
{
    public class StatusController:Controller
    {
        [HttpGet("status")]
        public IActionResult Status()
        {
            return Ok("All is right in the world");
        }
    }
}