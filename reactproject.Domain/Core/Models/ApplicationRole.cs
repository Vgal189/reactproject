using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson;
using MongoDbGenericRepository.Attributes;

namespace reactproject.Domain.Core
{
    [CollectionName("Roles")]
    public class ApplicationRole : MongoIdentityRole<ObjectId>
    {
        public ObjectId GenerateId()
        {
            return ObjectId.GenerateNewId();
        }
    }
}
