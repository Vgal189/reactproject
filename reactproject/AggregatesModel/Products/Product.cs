using reactproject.Models;

namespace reactproject.AggregatesModel.Product
{
    public class Product : Entity
    {
        public Product() { }
        public Product(string name, decimal price, string? description, List<string>? images)
        {
            Name = name;
            Price = price;
            Description = description;
            Images = images;
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public List<string>? Images { get; set; }
    }
}
