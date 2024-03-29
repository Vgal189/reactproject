﻿using MediatR;
using reactproject.Application.Commands.Orders;
using reactproject.Domain.AggregatesModel.Orders;
using reactproject.Repositories;

namespace reactproject.Application.Handler.Orders
{
    public class DeleteOrderRequestHandler : IRequestHandler<DeleteOrderRequest, bool>
    {
        private readonly Repository<Order> _repository;
        private const string COLLECTION_NAME = "order";

        public DeleteOrderRequestHandler(Repository<Order> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteOrderRequest request, CancellationToken cancellationToken)
        {
            var finalResult = await _repository.Delete(COLLECTION_NAME, cancellationToken, request.Id);

            return finalResult;
        }
    }
}
