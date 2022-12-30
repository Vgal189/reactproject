using reactproject.AggregatesModel.Products;

namespace reactproject.AggregatesModel.Orders
{
    public class OrderItem
    {
        public OrderItem(Product product, int quantity, decimal price)
        {
            Product = product;
            Quantity = quantity;
            Price = price;
        }

        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
