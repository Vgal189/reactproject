using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using reactproject.Models;

namespace reactproject.AggregatesModel.Person
{
    public class PersonModel : Entity
    {
        public PersonModel(string name, string phone, int age)
        {
            Name = name;
            Phone = phone;
            Age = age;
        }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }

    }
}
