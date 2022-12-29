using MediatR;
using Microsoft.AspNetCore.StaticFiles;
using MongoDB.Driver;
using reactproject.AggregatesModel.Product;
using reactproject.Models;
using System.Threading;

namespace reactproject.Repositories
{
    public class Repository<T> where T : Entity
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;

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

        public async Task<IMongoCollection<T>> Add(T document, string collectionName)
        {
            var collection = _database.GetCollection<T>(collectionName);
            await collection.InsertOneAsync(document);
            return collection;
        }
        public async Task<bool> Delete(string collectionName, CancellationToken cancellationToken,  string requestId)
        {
            var collection = _database.GetCollection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq(p => p.Id, requestId);
            var result = await collection.DeleteOneAsync(filter, cancellationToken);
            return result.DeletedCount > 0;
        }
    }
}
