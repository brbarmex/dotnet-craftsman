using System.Collections;
using System.Collections.Generic;

namespace Craftsman.Unit.Tests.Fixtures.ClassFixture.Cpf
{
    public class WithSpecialValues : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "@@@@@@@@@@" };
            yield return new object[] { "           " };
            yield return new object[] { string.Empty };
            yield return new object[] { null };
            yield return new object[] { "'\'object'\'" };
            yield return new object[] { "(**&$!#" };
            yield return new object[] { "******" };
            yield return new object[] { "SELECT 1 OR 1" };
        }

        IEnumerator IEnumerable.GetEnumerator()
        => default;
    }
}