using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheWorld.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using TheWorld.Models;
using System.Linq;

namespace TheWorld.Controllers.Api
{
    [Authorize]
    public class AccountController : Controller
    {
        private ILogger<AccountController> _logger;
        private SignInManager<WorldUser> _signInManager;
        private UserManager<WorldUser> _userManager;

        public AccountController(SignInManager<WorldUser> signInManager, ILogger<AccountController> logger, UserManager<WorldUser> userManager)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] RegisterLoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(modelError => modelError.ErrorMessage).ToList());
            }
            var user = new WorldUser
            {
                UserName = model.Email,
                Email = model.Email,
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(x => x.Description).ToList());
            }

            await _signInManager.SignInAsync(user, false);

            return Ok();
        }
    }
}
