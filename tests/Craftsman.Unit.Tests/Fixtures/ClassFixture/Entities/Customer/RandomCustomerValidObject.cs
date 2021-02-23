using System;
using System.Collections;
using System.Collections.Generic;
using Bogus;
using Bogus.Extensions.Brazil;

namespace Craftsman.Unit.Tests.Fixtures.ClassFixture.Entities.Customer
{
    public class RandomCustomerValidObject : IEnumerable<object[]>
    {
        private readonly IEnumerable<Domain.Entities.Customer> Customers;

        public RandomCustomerValidObject()
        {
            var fakes = new Faker<Domain.Entities.Customer>("pt_BR")
                            .CustomInstantiator(faker =>
                            new Domain.Entities.Customer(
                                faker.Name.FirstName(),
                                faker.Name.LastName(),
                                faker.Person.Cpf(),
                                faker.Internet.Email(),
                                faker.Date.PastOffset(20, DateTime.Now.AddYears(-18)).Date,
                                faker.Address.StreetAddress(),
                                faker.Address.ZipCode(),
                                faker.Address.City(),
                                faker.Address.Country()
                            ));

            Customers = fakes.Generate(100);
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            foreach (var item in Customers)
                yield return new object[] { item };
        }

        IEnumerator IEnumerable.GetEnumerator()
        => default;
    }
}