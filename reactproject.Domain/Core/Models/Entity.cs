using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace reactproject.Domain.Core
{
    public interface IEntity
    {
    }

    public abstract class Entity : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
