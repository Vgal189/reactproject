using MongoDB.Driver;
using reactproject.Domain.Core;

namespace reactproject.Repositories
{
    public class Repository<T> where T : Entity
    {
        protected readonly MongoClient _client;
        protected readonly IMongoDatabase _database;

        public Repository(string connectionString)
        {
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase("simple_db");
        }

        public async Task<List<T>> GetAllAsync(string collectionName)
        {
            var collection = _database.GetCollection<T>(collectionName);
            var filter = Builders<T>.Filter.Empty;
            return await collection.Find(filter).ToListAsync();
        }

        public async Task<T> GetByIdAsync(string collectionName, string id)
        {
            var collection = _database.GetCollection<T>(collectionName);
            return await collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetFilteredCollection<T>(string collectionName, FilterDefinition<T> filter)
        {
            var collection = _database.GetCollection<T>(collectionName);
            return await collection.Find(filter).ToListAsync();
        }

        public async Task<IMongoCollection<T>> Add(T document, string collectionName)
        {
            var collection = _database.GetCollection<T>(collectionName);
            await collection.InsertOneAsync(document);
            return collection;
        }
        public async Task<bool> Delete(string collectionName, CancellationToken cancellationToken,  string id)
        {
            var collection = _database.GetCollection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq(p => p.Id, id);
            var result = await collection.DeleteOneAsync(filter, cancellationToken);
            return result.DeletedCount > 0;
        }
        public async Task UpdateAsync(T document, string collectionName, string id)
        {
            var collection = _database.GetCollection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq(e => e.Id, id);
            await collection.ReplaceOneAsync(filter, document);
        }

    }
}
