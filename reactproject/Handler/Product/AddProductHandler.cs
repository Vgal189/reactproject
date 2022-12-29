using MediatR;
using MongoDB.Driver;
using reactproject.AggregatesModel.Product;
using reactproject.Commands.Person;
using reactproject.Commands.Product;
using reactproject.Repositories;

namespace reactproject.Handler.Product
{
    public class AddProductHandler : IRequestHandler<AddProductRequest, AddProductResponse>
    {
        private readonly Repository<ProductModel> _repository;
        private const string COLLECTION_NAME = "product";

        public AddProductHandler(Repository<ProductModel> repository)
        {
            _repository = repository;
        }

        public async Task<AddProductResponse> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            var document = new ProductModel(request.Name, request.Type, request.Price);

            await _repository.Add(document, COLLECTION_NAME);

            return new AddProductResponse(document.Id);
        }
    }
}
