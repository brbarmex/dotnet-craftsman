using System.Collections;
using System.Collections.Generic;

namespace Craftsman.Unit.Tests.Fixtures.ClassFixture.ZipCode
{
    public class InValidValueContainSpecialCharacteres : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new()};
        }

        IEnumerator IEnumerable.GetEnumerator()
        => default;
    }
}