using System.Collections;
using System.Collections.Generic;

namespace Craftsman.Unit.Tests.Fixtures.ClassFixture.Email
{
    public class EmailContainingSpecialValues : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { " @.com" };
            yield return new object[] { null };
            yield return new object[] { string.Empty };
        }

        IEnumerator IEnumerable.GetEnumerator()
        => default;
    }
}