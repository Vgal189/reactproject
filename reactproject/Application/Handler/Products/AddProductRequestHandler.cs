﻿using MediatR;
using reactproject.Application.Commands.Products;
using reactproject.Domain.AggregatesModel.Products;
using reactproject.Repositories;

namespace reactproject.Application.Handler.Products
{
    public class AddProductRequestHandler : IRequestHandler<AddProductRequest, AddProductResponse>
    {
        private readonly Repository<Product> _repository;
        private const string COLLECTION_NAME = "product";

        public AddProductRequestHandler(Repository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<AddProductResponse> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            var document = new Product(request.Name, request.Price, request.Description, request.Images);

            await _repository.Add(document, COLLECTION_NAME);

            return new AddProductResponse(document.Id);
        }
    }
}
