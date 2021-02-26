
using System.Collections;
using System.Collections.Generic;

namespace Craftsman.Unit.Tests.Fixtures.ClassFixture.Cpf
{
    public class WithOutFormattingWithValueInvalid : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "76558169014" };
            yield return new object[] { "74618508053" };
            yield return new object[] { "54067188012" };
            yield return new object[] { "16699712000" };
            yield return new object[] { "21012729005" };
            yield return new object[] { "86154387051" };
            yield return new object[] { "41693030031" };
            yield return new object[] { "57010763060" };
            yield return new object[] { "12005329064" };
            yield return new object[] { "34203777085" };
        }

        IEnumerator IEnumerable.GetEnumerator()
        => default;
    }
}