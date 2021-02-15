using System;

namespace Craftsman.Shared.Commands
{
    public class NewCustomer
    {
        public string Name { get; }
        public string FullName { get; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime BirthDate { get; set; }
    }
}