using MediatR;
using reactproject.Application.Commands.Products;
using reactproject.Domain.AggregatesModel.Products;
using reactproject.Repositories;

namespace reactproject.Application.Handler.Products
{
    public class DeleteProductRequestHandler : IRequestHandler<DeleteProductRequest, bool>
    {
        private readonly Repository<Product> _repository;
        private const string COLLECTION_NAME = "product";

        public DeleteProductRequestHandler(Repository<Product> repository)
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
