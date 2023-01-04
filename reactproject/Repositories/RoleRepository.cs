using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;
using reactproject.Application.Commands.Users;
using reactproject.Infrastructure.Configuration;

namespace reactproject.Repositories
{
    public class RoleRepository : ApplicationRole
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;
        private const string COLLECTION_NAME = "Roles";

        public RoleRepository(RoleManager<ApplicationRole> roleManager, string connectionString)
        {
            _roleManager = roleManager;
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase("simple_db");
        }
        public async Task<List<ApplicationRole>> GetAllAsync()
        {
            var collection = _database.GetCollection<ApplicationRole>(COLLECTION_NAME);
            var filter = Builders<ApplicationRole>.Filter.Empty;
            return await collection.Find(filter).ToListAsync();
        }
        public async Task<IdentityResult> CreateAsync(AddRoleRequest role)
        {
            return await _roleManager.CreateAsync(new ApplicationRole() { Name = role.RoleName });
        }
    }
}
