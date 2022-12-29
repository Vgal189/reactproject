using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using reactproject.Models;

namespace reactproject.AggregatesModel.Product
{
    public class ProductModel : Entity
    {
        public ProductModel(string name, ProductType type, int price)
        {
            Name = name;
            Type = type;
            Price = price;
        }
        public string Name { get; set; }
        public ProductType Type { get; set; }
        public int Price { get; set; }
    }
}
