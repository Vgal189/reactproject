using MediatR;
using reactproject.AggregatesModel.CostumerInfo;
using reactproject.Commands.Costumer;
using reactproject.Repositories;

namespace reactproject.Handler.Costumer
{
    public class AddCostumerInfoHandler : IRequestHandler<AddCustomerInfoRequest, AddCostumerInfoResponse>
    {
        private readonly Repository<CustomerInfo> _repository;
        private const string COLLECTION_NAME = "costumer";

        public AddCostumerInfoHandler(Repository<CustomerInfo> repository)
        {
            _repository= repository;
        }

        public async Task<AddCostumerInfoResponse> Handle(AddCustomerInfoRequest request, CancellationToken cancellationToken)
        {
            var document = new CustomerInfo(request.FirstName, request.LastName, request.Email, request.ShippingAddress, request.BillingAddress);
            
            await _repository.Add(document, COLLECTION_NAME);
            
            return new AddCostumerInfoResponse(document.Id);
        }
    }
}
