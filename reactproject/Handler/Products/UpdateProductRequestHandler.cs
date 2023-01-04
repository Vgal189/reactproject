using MediatR;
using reactproject.Commands.Products;
using reactproject.Domain.AggregatesModel.Products;
using reactproject.Repositories;

namespace reactproject.Handler.Products
{
    public class UpdateProductRequestHandler : IRequestHandler<UpdateProductRequest, bool>
    {
        private readonly Repository<Product> _repository;
        private const string COLLECTION_NAME = "product";


        public UpdateProductRequestHandler(Repository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(COLLECTION_NAME, request.Id);
            if (product == null)
                return false;

            product.Name = request.Name;
            product.Price = request.Price;
            product.Description = request.Description;
            product.Images = request.Images;

            await _repository.UpdateAsync(product, COLLECTION_NAME, request.Id);

            return true;
        }
    }

}
