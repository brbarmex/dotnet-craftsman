using Craftsman.Domain.ValueObjects;
using Craftsman.Unit.Tests.Fixtures.ClassFixture.Cpf;
using Xunit;

namespace FP.DotNet.Tests.ValueObjects
{
    public class CpfTest
    {
        [Theory]
        [Trait("CPF","Validate role of verification value.")]
        [ClassData(typeof(WithOutFormattingWithValidValue))]
        public void CPF_ValidateValueFormatted_MustBeValid_WhenValueIsValid(string value)
        {
            Cpf cpf = value;
            Assert.True(cpf.IsValid());
        }

        [Theory]
        [Trait("CPF","Validate role of verification value.")]
        [ClassData(typeof(WithOutFormattingWithValueInvalid))]
        public void CPF_ValidiateValueFormatted_MustBeInvalid_WhenValueIsInvalid(string value)
        {
            Cpf cpf = value;
            Assert.False(cpf.IsValid());
        }

        [Theory]
        [Trait("CPF","Validate role of verification value.")]
        [ClassData(typeof(WithSpecialValues))]
        public void CPF_ValidateSpecialValue_MustBeInvalid_WhenToContainSpecialValues(string value)
        {
            Cpf cpf = value;
            Assert.False(cpf.IsValid());
        }
    }
}