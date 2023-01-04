using MediatR;
using Newtonsoft.Json;

namespace reactproject.Application.Commands.Products
{
    public class UpdateProductRequest : IRequest<bool>
    {
        public UpdateProductRequest(string id, string name, decimal price, string? description, List<string>? images)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
            Images = images;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public List<string>? Images { get; set; }
    }
}
