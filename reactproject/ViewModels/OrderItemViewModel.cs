using reactproject.AggregatesModel.Product;

namespace reactproject.ViewModels
{
    public class OrderItemViewModel
    {
        public string ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
