using System.Collections;
using System.Collections.Generic;

namespace Craftsman.Unit.Tests.Fixtures.ClassFixture.ZipCode
{
    public class ValidZipCodeFormatted : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "04173-020" };
        }

        IEnumerator IEnumerable.GetEnumerator()
        => default;
    }
}