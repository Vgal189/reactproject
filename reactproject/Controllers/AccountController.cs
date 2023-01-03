using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using reactproject.Commands.Users;
using reactproject.Infrastructure.Configuration;
using System.ComponentModel.DataAnnotations;

namespace reactproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("/api/login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest login)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appUser = await _userManager.FindByEmailAsync(login.Email);
                if (appUser != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(appUser, login.Password, false, false);
                    if (result.Succeeded)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return BadRequest("Failed");
                    }
                }
            }
            return Ok();
        }

        [HttpOptions]
        [Route("/api/logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return Ok("Logout");
        }


    }
}
