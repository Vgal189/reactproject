using MediatR;

namespace reactproject.Commands.Products
{
    public class DeleteProductRequest : IRequest<bool>
    {
        public DeleteProductRequest(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
