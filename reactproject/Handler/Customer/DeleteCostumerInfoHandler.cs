﻿using MediatR;
using reactproject.AggregatesModel.CostumerInfo;
using reactproject.Commands.Customer;
using reactproject.Repositories;

namespace reactproject.Handler.Customer
{
    public class DeleteCustomerInfoHandler : IRequestHandler<DeleteCustomerInfoRequest, bool>
    {
        private readonly Repository<CustomerInfo> _repository;
        private const string COLLECTION_NAME = "customer";

        public DeleteCustomerInfoHandler(Repository<CustomerInfo> repository)
        {
            _repository= repository;
        }

        public async Task<bool> Handle(DeleteCustomerInfoRequest request, CancellationToken cancellationToken)
        {
            var finalResult = await _repository.Delete(COLLECTION_NAME, cancellationToken, request.Id);
 
            return finalResult;
        }
    }
}