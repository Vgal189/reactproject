using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace reactproject.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(ObjectId id, string name, string email, string? phoneNumber, bool phoneNumberConfirmed, bool emailConfirmed)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            PhoneNumberConfirmed = phoneNumberConfirmed;
            EmailConfirmed = emailConfirmed;
        }

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
