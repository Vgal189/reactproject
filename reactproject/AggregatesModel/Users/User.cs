using reactproject.Models;
using System.ComponentModel.DataAnnotations;

namespace reactproject.AggregatesModel.Users
{
    public class User : Entity
    {
        public User(string email, string passwordHash, string name)
        {
            Email = email;
            PasswordHash = passwordHash;
            Name = name;
        }

        [Required]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
