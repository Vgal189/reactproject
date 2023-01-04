using MediatR;
using reactproject.Domain.AggregatesModel.Orders;

namespace reactproject.Application.Commands.Orders
{
    public class AddOrderRequest : IRequest<AddOrderResponse>
    {
        public AddOrderRequest(string customerId, string orderNumber, DateTime orderDate, List<OrderItem> items)
        {
            CustomerId = customerId;
            OrderNumber = orderNumber;
            OrderDate = orderDate;
            Items = items;
        }
        public string CustomerId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItem> Items { get; set; }
    }

    public class AddOrderResponse
    {
        public AddOrderResponse(string id)
        {
            Id = id;
        }
        public string Id { get; set; }

    }
}
