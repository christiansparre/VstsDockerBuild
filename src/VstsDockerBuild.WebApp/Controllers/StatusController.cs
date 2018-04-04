using System;
using Microsoft.AspNetCore.Mvc;

namespace VstsDockerBuild.WebApp.Controllers
{
    public class StatusController:Controller
    {
        [HttpGet("status")]
        public IActionResult Status()
        {
            var blowUp = Environment.GetEnvironmentVariable("BLOWUPINTEGRATION");
            if (blowUp != null && blowUp == "yes")
            {
                return StatusCode(500);
            }
            
            return Ok("All is right in the world");
        }
    }
}