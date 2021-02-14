using System.Collections.Generic;
using FP.DotNet.Domain.ValueObjects;
using Xunit;

namespace FP.DotNet.Tests.ValueObjects
{
    public class CpfTest
    {
        [Theory]
        [MemberData(nameof(CpfDatas))]
        public void Should_Validate_CPF(bool expected, string value)
        {
            Cpf cpf = value;
            Assert.Equal(expected, cpf.IsValid());
        }

        public static IEnumerable<object[]> CpfDatas()
        {
            yield return new object[]{ true, "765.584.690-14"};
            yield return new object[]{ true, "76558469014"};
            yield return new object[]{ true, "74698508053"};
            yield return new object[]{ false, "746985080531"};
            yield return new object[]{ false, "ksanjbfysa"};
            yield return new object[]{ false, "1928448539"};
            yield return new object[]{ false, string.Empty};
        }
    }
}