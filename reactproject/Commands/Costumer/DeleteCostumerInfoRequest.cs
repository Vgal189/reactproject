using MediatR;

namespace reactproject.Commands.Costumer
{
    public class DeleteCustomerInfoRequest : IRequest<bool>
    {
        public DeleteCustomerInfoRequest(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}