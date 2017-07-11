
using Microsoft.AspNetCore.Mvc;
using TheWorld.Models;

namespace TheWorld.Controllers.Api
{
    public class TripsController : Controller
    {
        [HttpGet("api/trips")]
        public JsonResult Get()
        {
            return Json(new Trip() { Name = "My Trip" });
        }
    }
}
