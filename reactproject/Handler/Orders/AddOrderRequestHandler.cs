using MediatR;
using reactproject.Commands.Orders;
using reactproject.Domain.AggregatesModel.Orders;
using reactproject.Repositories;

namespace reactproject.Handler.Orders
{
    public class AddOrderRequestHandler : IRequestHandler<AddOrderRequest, AddOrderResponse>
    {
        private readonly Repository<Order> _repository;
        private const string COLLECTION_NAME = "order";

        public AddOrderRequestHandler(Repository<Order> repository)
        {
            _repository = repository;
        }

        public async Task<AddOrderResponse> Handle(AddOrderRequest request, CancellationToken cancellationToken)
        {

            var document = new Order(request.CustomerId, request.OrderNumber, request.OrderDate, request.Items);

            await _repository.Add(document, COLLECTION_NAME);

            return new AddOrderResponse(document.Id);
        }
    }
}
