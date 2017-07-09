using System;
using Microsoft.AspNetCore.Mvc;
using TheWorld.Services;
using TheWorld.ViewModels;
using Microsoft.Extensions.Configuration;
using TheWorld.Models;
using System.Linq;

namespace TheWorld.Controllers
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        private IConfiguration _config;
        private WorldContext _context;

        public AppController(IMailService mailService, IConfiguration config, WorldContext context)
        {
            _mailService = mailService;
            _config = config;
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.Trips.ToList();
            return View(data);
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel contact)
        {
            if (contact.Email.Contains("aol.com")) ModelState.AddModelError("Email", "We don't support aol addresses");

            if (ModelState.IsValid)
            {
                _mailService.SendMail(_config["MailSettings:ToAddress"], contact.Email, "From The World", contact.Message);
                ModelState.Clear();
                ViewBag.UserMessage = "Message Sent successfully";
            }

            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
