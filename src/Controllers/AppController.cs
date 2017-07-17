using System;
using Microsoft.AspNetCore.Mvc;
using TheWorld.Services;
using TheWorld.ViewModels;
using Microsoft.Extensions.Configuration;
using TheWorld.Models;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace TheWorld.Controllers
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        private IConfiguration _config;
        private IWorldRepository _repository;
        private ILogger<AppController> _logger;

        public AppController(IMailService mailService, IConfiguration config, IWorldRepository repository, ILogger<AppController> logger)
        {
            _mailService = mailService;
            _config = config;
            _repository = repository;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Trips()
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
