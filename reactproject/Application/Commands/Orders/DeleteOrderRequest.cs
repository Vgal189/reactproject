using MediatR;

namespace reactproject.Application.Commands.Orders
{
    public class DeleteOrderRequest : IRequest<bool>
    {
        public DeleteOrderRequest(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
