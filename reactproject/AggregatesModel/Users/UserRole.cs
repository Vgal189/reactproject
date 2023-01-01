using reactproject.Models;

namespace reactproject.AggregatesModel.Users
{
    public class UserRole
    {
        public UserRole(string roleName)
        {
            RoleName = roleName;
        }

        public string RoleName { get; set; }

    }
}
