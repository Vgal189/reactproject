using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson;
using MongoDbGenericRepository.Attributes;

namespace reactproject.Domain.Core
{
    [CollectionName("Users")]
    public class ApplicationUser : MongoIdentityUser<ObjectId>
    {
        public ObjectId GenerateId()
        {
            return ObjectId.GenerateNewId();
        }
    }
}