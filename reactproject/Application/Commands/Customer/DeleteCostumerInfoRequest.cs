using MediatR;

namespace reactproject.Application.Commands.Customer
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