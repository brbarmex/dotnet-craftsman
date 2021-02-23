using System.Collections;
using System.Collections.Generic;

namespace Craftsman.Unit.Tests.Fixtures.ClassFixture.Email
{
    public class InvalidFormatting : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "@teste.com" };
            yield return new object[] { "@teste@com" };
            yield return new object[] { " @ .com" };
            yield return new object[] { "abc abc@live.com" };
            yield return new object[] { "abc abc@live-mail.com" };
        }

        IEnumerator IEnumerable.GetEnumerator()
        => default;
    }
}