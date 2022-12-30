using MediatR;

namespace reactproject.Commands.Products
{
    public class AddProductRequest : IRequest<AddProductResponse>
    {
        public AddProductRequest(string name, decimal price, string? description, List<string>? images)
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

    public class AddProductResponse
    {
        public AddProductResponse(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
