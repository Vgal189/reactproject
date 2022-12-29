using MediatR;

namespace reactproject.Commands.Person
{
    public class DeletePersonRequest : IRequest<bool>
    {
        public DeletePersonRequest(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}