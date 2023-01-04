using MongoDB.Driver;
using MongoDB.Driver.Linq;
using reactproject.Application.ViewModels;
using reactproject.Domain.AggregatesModel.Customer;
using reactproject.Domain.AggregatesModel.Orders;
using reactproject.Domain.AggregatesModel.Products;


namespace reactproject.Repositories
{
    public class OrderRepository : Repository<Order>
    {
        public OrderRepository(string connectionString) : base(connectionString)
        {
        }

        public async Task<List<OrderViewModel>> GetAllOrdersAsync()
        {
            var orders = await GetFilteredCollection<OrderViewModel>("order", Builders<OrderViewModel>.Filter.Empty);
            var customers = await GetFilteredCollection<CustomerInfo>("customer", Builders<CustomerInfo>.Filter.Empty);
            var products = await GetFilteredCollection<Product>("product", Builders<Product>.Filter.Empty);

            var productLookup = products.ToDictionary(p => p.Id);

            var query = from o in orders
                        join c in customers on o.CustomerId equals c.Id
                        select new OrderViewModel
                        {
                            Id = o.Id,
                            CustomerId = o.CustomerId,
                            Customer = new CustomerInfoViewModel(c.FirstName,
                                                                c.LastName,
                                                                c.Email,
                                                                c.ShippingAddress,
                                                                c.BillingAddress),
                            OrderNumber = o.OrderNumber,
                            OrderDate = o.OrderDate,
                            Items = o.Items.Select(item => new OrderItemViewModel
                            {
                                ProductId = item.ProductId,
                                Product = productLookup[item.ProductId],
                                Quantity = item.Quantity,
                                Price = productLookup[item.ProductId].Price * item.Quantity
                            }).ToList(),
                            TotalPrice = o.Items.Sum(item => productLookup[item.ProductId].Price * item.Quantity)
                        };

            var result = query.ToList();

            return result;

        }

    }
}
