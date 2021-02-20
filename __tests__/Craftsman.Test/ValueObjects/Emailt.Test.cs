using Craftsman.Shared.ValueObjects;
using FP.DotNet.Tests.ClassDatas;
using Xunit;

namespace FP.DotNet.Tests.ValueObjects
{
    public class EmailTest
    {
        [Theory]
        [ClassData(typeof(EmailClassDataForValidateFunctionThatCheckEmail))]
        public void Should_Validate_Email(bool expected, string value)
        {
            Email email = value;
            Assert.Equal(expected, email.IsValid());
        }
    }
}