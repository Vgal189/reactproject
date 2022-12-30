using MongoDB.Bson;
using reactproject.AggregatesModel.CostumerInfo;
using reactproject.AggregatesModel.Orders;
using reactproject.Models;

namespace reactproject.AggregatesModel.Order
{
    public class Order : Entity
    {
        public Order(string orderNumber, DateTime orderDate, CustomerInfo customer, List<OrderItem> items)
        {
            OrderNumber = orderNumber;
            OrderDate = orderDate;
            Customer = customer;
            Items = items;
        }

        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public CustomerInfo Customer { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
