using System;

namespace Craftsman.Shared.Commands
{
    public class NewCustomerCommand
    {
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