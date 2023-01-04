using reactproject.Domain.Core;

namespace reactproject.Domain.AggregatesModel.Orders
{
    public class Order : Entity
    {
        public Order(string customerId, string orderNumber, DateTime orderDate, List<OrderItem> items)
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
}
