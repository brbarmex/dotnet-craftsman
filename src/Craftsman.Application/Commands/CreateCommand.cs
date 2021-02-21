using System;
using System.Collections.Generic;
using Craftsman.Domain.Bases;
using MediatR;
using OneOf;

namespace Craftsman.Application.Boundaries.Customer.Commands
{
    public class CreateCommand : IRequest<OneOf<List<Notification>, CreateCommand,Exception>>
    {
        public Guid Id {get; set;}
        public string Name { get; set;}
        public string FullName { get; set;}
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime BirthDate { get; set; }
    }
}