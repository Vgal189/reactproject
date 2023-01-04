using System.ComponentModel.DataAnnotations;

namespace reactproject.Application.Commands.Users
{
    public class AddUserRequest
    {
        public AddUserRequest(string email, string passwordHash, string userName, string? role)
        {
            Email = email;
            PasswordHash = passwordHash;
            UserName = userName;
            Role = role;
        }

        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string UserName { get; set; }
        public string? Role { get; set; }
    }
}
