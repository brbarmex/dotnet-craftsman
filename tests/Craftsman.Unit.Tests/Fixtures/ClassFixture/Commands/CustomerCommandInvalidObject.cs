using System.Collections;
using System.Collections.Generic;
using Craftsman.Application.Boundaries.Customer.Commands;

namespace Craftsman.Unit.Tests.Fixtures.ClassFixture.Commands
{
    public class CustomerCommandInvalidObject : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new CreateCommand
                {
                   Name      =   string.Empty,
                   FullName  =   string.Empty,
                   Cpf       =    string.Empty,
                   Email     =   string.Empty,
                   BirthDate =  default,
                   Street    =  string.Empty,
                   ZipCode   =  string.Empty,
                   Country   =  string.Empty,
                   City      =  string.Empty
                }
            };

            yield return new object[]
            {
                new CreateCommand
                {
                    Name     =   null,
                    FullName =   null,
                    Cpf      =   null,
                    Email    =   null,
                    BirthDate =  default,
                    Street    =  null,
                    ZipCode   =  null,
                    Country   =  null,
                    City      =  null
                }
            };

            yield return new object[]
            {
                new CreateCommand
                {
                    Name     =   "                                                           ",
                    FullName =   "                                                           ",
                    Cpf      =   "                                                           ",
                    Email    =   "                                                           ",
                    BirthDate =  default,
                    Street    =  "                                                           ",
                    ZipCode   =  "                                                           ",
                    Country   =  "                                                           ",
                    City      =  "                                                           "
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        => default;
    }
}