using MediatR;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using reactproject.AggregatesModel.Person;
using reactproject.Commands.Person;
using reactproject.Repositories;

namespace reactproject.Handler.Person
{
    public class AddPersonHandler : IRequestHandler<AddPersonRequest, AddPersonResponse>
    {
        private readonly Repository<PersonModel> _repository;
        private const string COLLECTION_NAME = "person";

        public AddPersonHandler(Repository<PersonModel> repository)
        {
            _repository= repository;
        }

        public async Task<AddPersonResponse> Handle(AddPersonRequest request, CancellationToken cancellationToken)
        {
            var document = new PersonModel(request.Name, request.Phone, request.Age);
            
            await _repository.Add(document, COLLECTION_NAME);
            
            return new AddPersonResponse(document.Id);
        }
    }
}
