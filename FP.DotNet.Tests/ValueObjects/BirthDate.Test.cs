using System;
using FP.DotNet.Domain.ValueObjects;
using FP.DotNet.Tests.MemberDatas;
using Xunit;

namespace FP.DotNet.Tests.ValueObjects
{
    public class BirthDateTest
    {
        [Theory]
        [ClassData(typeof(BirthDateClassDatas))]
        public void Should_Validate_If_Is_Adult(bool expected, DateTime value)
        {
            BirthDate birthDate = value;
            Assert.Equal(expected, birthDate.IsAdult);
        }
    }
}