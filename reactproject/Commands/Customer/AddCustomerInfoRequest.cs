using MediatR;
using reactproject.Domain.AggregatesModel.Customer;

namespace reactproject.Commands.Customer
{
    public class AddCustomerInfoRequest : IRequest<AddCustomerInfoResponse>
    {
        public AddCustomerInfoRequest(string firstName, string lastName, string email, Address shippingAddress, Address billingAddress)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            ShippingAddress = shippingAddress;
            BillingAddress = billingAddress;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Address ShippingAddress { get; set; }
        public Address BillingAddress { get; set; }
    }

    public class AddCustomerInfoResponse
    {
        public AddCustomerInfoResponse(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
