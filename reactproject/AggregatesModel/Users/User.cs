using reactproject.Models;

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

        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Name { get; set; }
    }
}
