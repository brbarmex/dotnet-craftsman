using System;
using System.Collections;
using System.Collections.Generic;

namespace Craftsman.Unit.Tests.Fixtures.ClassFixture.BirthDate
{
    public class AdultBirthday : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new DateTime(1994, 7, 30) };
            yield return new object[] { new DateTime(1998, 6, 25) };
            yield return new object[] { new DateTime(2000, 12, 17) };
            yield return new object[] { new DateTime(2003, 12, 31) };
        }

        IEnumerator IEnumerable.GetEnumerator()
        => default;
    }
}