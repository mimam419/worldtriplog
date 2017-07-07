using Microsoft.AspNetCore.Mvc;

namespace TheWorld.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
