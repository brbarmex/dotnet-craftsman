using Craftsman.Shared.ValueObjects;
using FP.DotNet.Tests.ClassDatas;
using Xunit;

namespace FP.DotNet.Tests.ValueObjects
{
    public class ZipCodeTest
    {
        [Theory]
        [ClassData(typeof(ZipoCodeClassData))]
        public void Should_Validate_ZipCode(bool expected, string value)
        {
            ZipCode zipCode = value;
            Assert.Equal(expected, zipCode.IsValid());
        }
    }
}