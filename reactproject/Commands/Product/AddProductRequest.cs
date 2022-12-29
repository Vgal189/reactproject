using MediatR;
using reactproject.AggregatesModel.Product;

namespace reactproject.Commands.Product
{
    public class AddProductRequest : IRequest<AddProductResponse>
    {
        public AddProductRequest(string name, ProductType type, int price)
        {
            Name = name;
            Type = type;
            Price = price;
        }
        public string Name { get; set; }
        public ProductType Type { get; set; }
        public int Price { get; set; }
    }

    public class AddProductResponse
    {
        public AddProductResponse(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
