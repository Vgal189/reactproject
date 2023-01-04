using MediatR;
using reactproject.Application.Commands.Customer;
using reactproject.Domain.AggregatesModel.Customer;
using reactproject.Repositories;

namespace reactproject.Application.Handler.Customer
{
    public class AddCustomerInfoHandler : IRequestHandler<AddCustomerInfoRequest, AddCustomerInfoResponse>
    {
        private readonly Repository<CustomerInfo> _repository;
        private const string COLLECTION_NAME = "customer";

        public AddCustomerInfoHandler(Repository<CustomerInfo> repository)
        {
            _repository = repository;
        }

        public async Task<AddCustomerInfoResponse> Handle(AddCustomerInfoRequest request, CancellationToken cancellationToken)
        {
            var document = new CustomerInfo(request.FirstName, request.LastName, request.Email, request.ShippingAddress, request.BillingAddress);

            await _repository.Add(document, COLLECTION_NAME);

            return new AddCustomerInfoResponse(document.Id);
        }
    }
}
