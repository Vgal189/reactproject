﻿using MediatR;

namespace reactproject.Commands.Orders
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
