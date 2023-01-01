using System.ComponentModel.DataAnnotations;

namespace reactproject.Commands.Users
{
    public class AddUserRequest
    {
        public AddUserRequest(string email, string passwordHash, string name)
        {
            Email = email;
            PasswordHash = passwordHash;
            Name = name;
        }

        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Name { get; set; }
    }
}
