using Craftsman.Domain.ValueObjects;
using Craftsman.Unit.Tests.Fixtures.ClassFixture.ZipCode;
using Xunit;

namespace Craftsman.Unit.Tests.ValueObjects
{
    public class ZipCodeTest
    {
        [Theory]
        [Trait("ZipCode","")]
        [ClassData(typeof(ValidZipCodeFormatted))]
        public void ZipCode_Validate_MustBeValid_WhenValueFormattedIsValid(string value)
        {
            ZipCode zipCode = value;
            Assert.True(zipCode.IsValid());
        }

        [Theory]
        [Trait("ZipCode","")]
        [ClassData(typeof(InValidZipCodeFormatted))]
        public void ZipCode_Validate_MustBeInvalid_WhenValueFormattedIsInvalid(string value)
        {
            ZipCode zipCode = value;
            Assert.True(zipCode.IsValid());
        }
    }
}