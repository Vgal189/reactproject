using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using reactproject.Application.Commands.Users;
using reactproject.Repositories;
using System.ComponentModel.DataAnnotations;

namespace reactproject.Controllers
{
    [ApiController]
    //[Authorize(Roles = "Admin, Manager")]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly UserRepository _userRepository;
        private readonly RoleRepository _roleRepository;

        public UserController(UserRepository userRepository, RoleRepository roleRepository) 
        {
            _userRepository= userRepository;
            _roleRepository = roleRepository;
        }

        [HttpGet]
        [Route("/api/user")]
        public async Task<IActionResult> Get()
        {
            if (ModelState.IsValid)
            {
                if (await _userRepository.GetAllAsync() == null)
                    return NoContent();
            }
            var documents = await _userRepository.GetAllAsync();

            return Ok(documents);
        }

        [HttpGet]
        [Route("/api/user/{email}")]
        public async Task<IActionResult> Get(string email)
        {
            if (ModelState.IsValid)
            {
                if (await _userRepository.GetByEmailAsync(email) == null)
                    return NoContent();
            }
            var documents = await _userRepository.GetByEmailAsync(email);

            return Ok(documents);
        }

        [HttpPost]
        [Route("/api/user")]
        public async Task<IActionResult> Create([FromBody]AddUserRequest user)
        {
            if (ModelState.IsValid)
            {
                if (await _roleRepository.GetAllAsync() == null)
                    return BadRequest("Invalid Role");

                if (await _userRepository.GetByEmailAsync(user.Email) != null)
                    return BadRequest("Email already in use");

                var result = await _userRepository.CreateAsync(user);
                if (result.Errors.Any())
                {
                    foreach (IdentityError error in result.Errors)
                        return BadRequest($"{error.Description}");
                }
            }
            return Ok($"Succeeded - {user}");
        }

        [HttpPost]
        [Route("/api/role")]
        public async Task<IActionResult> CreateRole([FromBody][Required] AddRoleRequest userRole)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleRepository.CreateAsync(userRole);
                if (result.Errors.Any())
                {
                    foreach (IdentityError error in result.Errors)
                        return BadRequest($"{error.Description}");
                }
            }
            return Ok("Role Created: " + userRole.RoleName);
        }
    }
}
