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
    [Route("api/account")]
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

        [HttpPost("create")]
        [AllowAnonymous]
        //[Route("create")]
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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] RegisterLoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Incorrect credential format");
            }

            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                return BadRequest("Username or password is incorrect");
            }

            return Ok("Signed in successfully");
        }
    }
}
