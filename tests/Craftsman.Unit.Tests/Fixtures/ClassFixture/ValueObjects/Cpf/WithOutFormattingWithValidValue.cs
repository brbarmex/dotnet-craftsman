using System.Collections;
using System.Collections.Generic;

namespace Craftsman.Unit.Tests.Fixtures.ClassFixture.Cpf
{
    public class WithOutFormattingWithValidValue : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "76558469014" };
            yield return new object[] { "74698508053" };
            yield return new object[] { "54067388012" };
            yield return new object[] { "16699716000" };
            yield return new object[] { "25012729005" };
            yield return new object[] { "86854387051" };
            yield return new object[] { "44693030031" };
            yield return new object[] { "57000763060" };
            yield return new object[] { "12015329064" };
            yield return new object[] { "34003777085" };
        }

        IEnumerator IEnumerable.GetEnumerator()
        => default;
    }
}