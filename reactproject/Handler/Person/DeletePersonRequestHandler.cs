using MediatR;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using reactproject.AggregatesModel.Person;
using reactproject.Commands.Person;
using reactproject.Repositories;

namespace reactproject.Handler.Person
{
    public class DeletePersonRequestHandler : IRequestHandler<DeletePersonRequest, bool>
    {
        private readonly Repository<PersonModel> _repository;
        private const string COLLECTION_NAME = "person";

        public DeletePersonRequestHandler(Repository<PersonModel> repository)
        {
            _repository= repository;
        }

        public async Task<bool> Handle(DeletePersonRequest request, CancellationToken cancellationToken)
        {
            var finalResult = await _repository.Delete(COLLECTION_NAME, cancellationToken, request.Id);
 
            return finalResult;
        }
    }
}
