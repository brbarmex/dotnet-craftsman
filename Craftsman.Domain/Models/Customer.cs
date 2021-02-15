using System;
using Craftsman.Domain.Validators;
using Craftsman.Shared.Bases;
using Craftsman.Shared.ValueObjects;

namespace Craftsman.Domain.Models
{
    public class Customer : Entity
    {
        public Customer(string name, string fullName, string cpf, string email,
                        DateTime birthDate, string street, string zipcode, string city,
                        string country
        )
        {
            Name = name;
            FullName = fullName;
            Cpf = cpf;
            Email = email;
            BirthDate = birthDate;
            Address = new Address
            {
                Street = street,
                ZipCode = zipcode,
                City = city,
                Country = country
            };

            ValidateDomain(this, new CustomerValidator());
        }

        public string Name { get; }
        public string FullName { get; }
        public Cpf Cpf { get; }
        public Address Address { get; }
        public BirthDate BirthDate { get; }
        public Email Email { get; }
    }
}