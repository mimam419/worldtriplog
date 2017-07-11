
using Microsoft.AspNetCore.Mvc;
using TheWorld.Models;

namespace TheWorld.Controllers.Api
{
    public class TripsController : Controller
    {
        [HttpGet("api/trips")]
        public IActionResult Get()
        {
            return Ok(new Trip() { Name = "My Trip" });
        }
    }
}
