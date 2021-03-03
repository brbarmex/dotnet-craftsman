using System;
using System.Collections.Generic;
using Craftsman.Domain.Bases;
using MediatR;
using OneOf;

namespace Craftsman.Application.Commands
{
    public class EditAddressCustomerCommand : IRequest<OneOf<List<Notification>, EditAddressCustomerCommand, Exception>>
    {
        public Guid Id {get; set;}
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}