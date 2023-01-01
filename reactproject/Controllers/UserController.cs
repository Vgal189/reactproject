﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using reactproject.AggregatesModel.Users;
using reactproject.Commands.Users;
using reactproject.Infrastructure.Configuration;
using reactproject.Repositories;
using System.ComponentModel.DataAnnotations;

namespace reactproject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly Repository<User> _repository;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<ApplicationRole> _roleManager;

        public UserController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager) 
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
        }

        [HttpPost]
        [Route("/api/user")]
        public async Task<IActionResult> Create([FromBody]AddUserRequest user, [FromQuery] string role)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser appUser = new ApplicationUser
                {
                    UserName = user.Name,
                    Email = user.Email
                };

                IdentityResult result = await _userManager.CreateAsync(appUser, user.PasswordHash);
                if (result.Errors.Any())
                {
                    foreach (IdentityError error in result.Errors)
                        return BadRequest($"{error.Description}");
                }
                //if(role =! )
                await _userManager.AddToRoleAsync(appUser, role);
            }

            return Ok($"Succeeded - {user}");
        }

        [HttpPost]
        [Route("/api/role")]
        public async Task<IActionResult> CreateRole([Required] AddRoleRequest userRole)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _roleManager.CreateAsync(new ApplicationRole() { Name = userRole.RoleName });
                if (result.Succeeded)
                {
                    return Ok($"Succeeded - {userRole}");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                        return BadRequest($"{error.Description}");
                }
            }
            return Ok(userRole);
        }
    }
}
