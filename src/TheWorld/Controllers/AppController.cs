using System;
using Microsoft.AspNetCore.Mvc;
using TheWorld.ViewModels;

namespace TheWorld.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel contact)
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
