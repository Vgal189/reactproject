using System.ComponentModel.DataAnnotations;

namespace reactproject.Commands.Users
{
    public class LoginRequest
    {
        [Required][EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
