using System;
using System.Collections;
using System.Collections.Generic;

namespace Craftsman.Unit.Tests.Fixtures.ClassFixture.BirthDate
{
    public class TeenagerOrChildBirthDay: IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new DateTime(2007, 7, 30) };
            yield return new object[] { new DateTime(2006, 6, 25) };
            yield return new object[] { new DateTime(2005, 12, 17) };
            yield return new object[] { new DateTime(2004, 01, 01) };
        }

        IEnumerator IEnumerable.GetEnumerator()
        => default;
    }
}