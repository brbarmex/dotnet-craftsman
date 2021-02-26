using Craftsman.Domain.ValueObjects;
using Craftsman.Unit.Tests.Fixtures.ClassFixture.Email;
using Xunit;

namespace Craftsman.Unit.Tests.ValueObjects
{
    public class EmailTest
    {
        [Theory]
        [Trait("Email","Validate role of verification value.")]
        [ClassData(typeof(InvalidFormatting))]
        public void Email_IsValid_MustBeFalse_WhenValueIsInvalid(string value)
        {
            Email email = value;
            Assert.False(email.IsValid());
        }

        [Theory]
        [Trait("Email","Validate role of verification value.")]
        [ClassData(typeof(EmailContainingSpecialValues))]
        public void Email_IsValid_MustBeFalse_WhenValueToContainSpecialCharacter(string value)
        {
            Email email = value;
            Assert.False(email.IsValid());
        }
    }
}