using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace reactproject.Application.ViewModels
{
    public class UserViewModel
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool EmailConfirmed { get; set; }

    }
}
