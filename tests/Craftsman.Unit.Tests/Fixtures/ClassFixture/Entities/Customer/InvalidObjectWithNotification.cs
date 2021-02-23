using System;
using System.Collections;
using System.Collections.Generic;

namespace Craftsman.Unit.Tests.Fixtures.ClassFixture.Entities.Customer
{
    public class InvalidObjectWithNotification : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]{
                new Domain.Entities.Customer(
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    default,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty),
                };
        }

        IEnumerator IEnumerable.GetEnumerator()
        => default;
    }
}