﻿using reactproject.AggregatesModel.Customer;
using reactproject.Models;
using System.Net;

namespace reactproject.AggregatesModel.CostumerInfo
{
    public class CustomerInfo : Entity
    {
        public CustomerInfo(string firstName, string lastName, string email, Address shippingAddress, Address billingAddress)
        {
            FirstName= firstName;
            LastName= lastName;
            Email= email;
            ShippingAddress= shippingAddress;
            BillingAddress= billingAddress;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Address ShippingAddress { get; set; }
        public Address BillingAddress { get; set; }

    }
}
