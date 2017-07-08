using System;
using Microsoft.AspNetCore.Mvc;
using TheWorld.Services;
using TheWorld.ViewModels;
using Microsoft.Extensions.Configuration;

namespace TheWorld.Controllers
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        private IConfiguration _config;

        public AppController(IMailService mailService, IConfiguration config)
        {
            _mailService = mailService;
            _config = config;
        }
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
            _mailService.SendMail(_config["MailSettings:ToAddress"], contact.Email, "From The World", contact.Message);
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
