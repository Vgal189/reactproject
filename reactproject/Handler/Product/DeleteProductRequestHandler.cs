using MediatR;
using reactproject.AggregatesModel.Product;
using reactproject.Commands.Product;
using reactproject.Repositories;

namespace reactproject.Handler.Product
{
    public class DeleteProductRequestHandler : IRequestHandler<DeleteProductRequest, bool>
    {
        private readonly Repository<ProductModel> _repository;
        private const string COLLECTION_NAME = "product";

        public DeleteProductRequestHandler(Repository<ProductModel> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var finalResult = await _repository.Delete(COLLECTION_NAME, cancellationToken, request.Id);

            return finalResult;
        }
    }
}
