using Craftsman.Shared.ValueObjects;
using FP.DotNet.Tests.MemberDatas;
using Xunit;

namespace FP.DotNet.Tests.ValueObjects
{
    public class CpfTest
    {
        [Theory]
        [ClassData(typeof(CpfClassData))]
        public void Should_Validate_CPF(bool expected, string value)
        {
            Cpf cpf = value;
            Assert.Equal(expected, cpf.IsValid());
        }
    }
}