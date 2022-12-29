using MediatR;
using System.Windows.Input;

namespace reactproject.Commands.Person
{
    public class AddPersonRequest : IRequest<AddPersonResponse>
    {
        public AddPersonRequest(string name, string phone, int age)
        {
            Name = name;
            Phone = phone;
            Age = age;
        }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
    }

    public class AddPersonResponse
    {
        public AddPersonResponse(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
