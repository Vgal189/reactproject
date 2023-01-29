using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using reactproject.Application.Commands.Users;
using reactproject.Domain.Core;
using reactproject.Identity.Services;
using reactproject.Infrastructure.Configuration;

namespace reactproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly TokenService _tokenService = new TokenService();

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, TokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
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
                        var token = _tokenService.GenerateToken(appUser);
                        return Ok(token.ToJson());
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
