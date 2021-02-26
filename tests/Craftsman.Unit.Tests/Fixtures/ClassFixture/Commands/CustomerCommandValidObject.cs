using System;
using System.Collections;
using System.Collections.Generic;
using Bogus;
using Bogus.Extensions.Brazil;
using Craftsman.Application.Boundaries.Customer.Commands;

namespace Craftsman.Unit.Tests.Fixtures.ClassFixture.Commands
{
    public class CustomerCommandValidObject : IEnumerable<object[]>
    {
        private readonly List<CreateCommand> CreateCommands;

        public CustomerCommandValidObject()
        {
            var fakes = new Faker<CreateCommand>("pt_BR")
                            .RuleFor(data => data.Name      , f => f.Name.FirstName())
                            .RuleFor(data => data.FullName  , f => f.Name.LastName())
                            .RuleFor(data => data.Cpf       , f => f.Person.Cpf())
                            .RuleFor(data => data.Email     , f => f.Internet.Email())
                            .RuleFor(data => data.BirthDate , f => f.Date.PastOffset(20, DateTime.Now.AddYears(-18)).Date)
                            .RuleFor(data => data.Street    , f => f.Address.StreetAddress())
                            .RuleFor(data => data.ZipCode   , f => f.Address.ZipCode())
                            .RuleFor(data => data.Country   , f => f.Address.City())
                            .RuleFor(data => data.City      , f => f.Address.Country());

            CreateCommands = fakes.Generate(100);
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            foreach (var item in CreateCommands)
                yield return new object[] { item };
        }

        IEnumerator IEnumerable.GetEnumerator()
        => default;
    }
}