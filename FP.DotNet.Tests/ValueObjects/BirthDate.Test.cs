using System;
using System.Collections.Generic;
using FP.DotNet.Domain.ValueObjects;
using Xunit;

namespace FP.DotNet.Tests.ValueObjects
{
    public class BirthDateTest
    {
        [Theory]
        [MemberData(nameof(BirthDateDatas))]
        public void Should_Validate_If_Is_Adult(bool expected, DateTime value)
        {
            BirthDate birthDate = value;
            Assert.Equal(expected, birthDate.IsAdult);
        }

        public static IEnumerable<object[]> BirthDateDatas()
        {
            yield return new object[]{ true, new DateTime(1994,7,30) };
            yield return new object[]{ false, new DateTime(2020,01,01) };
        }
    }
}