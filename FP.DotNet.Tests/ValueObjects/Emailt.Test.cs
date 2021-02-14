using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FP.DotNet.Domain.ValueObjects;
using Xunit;

namespace FP.DotNet.Tests.ValueObjects
{
    public class EmailTest
    {
        [Theory]
        [MemberData(nameof(EmailDatas))]
        public void Should_Validate_Email(bool expected, string value)
        {
            Email email = value;
            Assert.Equal(expected, email.IsValid());
        }

        public static IEnumerable<object[]> EmailDatas()
        {
            yield return new object[] { true, "bruno.b.melo@live.com" };
            yield return new object[] { false, "bruno.b.melolive.com" };
            yield return new object[] { false, string.Empty };
            yield return new object[] { false, "bruno.b.melo@livecom" };
        }
    }
}