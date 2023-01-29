using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;
using reactproject.Application.Commands.Users;
using reactproject.Domain.Core;

namespace reactproject.Repositories
{
    public class UserRepository : ApplicationUser
    {
        protected readonly UserManager<ApplicationUser> _userManager;
        protected readonly MongoClient _client;
        protected readonly IMongoDatabase _database;
        private const string COLLECTION_NAME = "Users";

        public UserRepository(UserManager<ApplicationUser> userManager, string connectionString)
        {
            _userManager = userManager;
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase("simple_db");
        }

        public async Task<List<ApplicationUser>> GetAllAsync()
        {
            var collection = _database.GetCollection<ApplicationUser>(COLLECTION_NAME);
            var filter = Builders<ApplicationUser>.Filter.Empty;
            return await collection.Find(filter).ToListAsync();
        }
        public async Task<ApplicationUser> GetByEmailAsync(string email)
        {
            var collection = _database.GetCollection<ApplicationUser>(COLLECTION_NAME);
            var user = await collection.Find(x => x.Email == email).FirstOrDefaultAsync();
            return user;
        }
        public async Task<IdentityResult> CreateAsync(AddUserRequest user)
        {
            ApplicationUser appUser = new ApplicationUser
            {
                UserName = user.UserName,
                Email = user.Email
            };
            var createdUser = await _userManager.CreateAsync(appUser, user.PasswordHash);
            await _userManager.AddToRoleAsync(appUser, user.Role);

            return createdUser;
        }
    }
}
