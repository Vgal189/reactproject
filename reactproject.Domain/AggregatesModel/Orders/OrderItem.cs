namespace reactproject.Domain.AggregatesModel.Orders
{
    public class OrderItem
    {
        public OrderItem() { }
        public OrderItem(string productId, int quantity, decimal price)
        {
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }

        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
