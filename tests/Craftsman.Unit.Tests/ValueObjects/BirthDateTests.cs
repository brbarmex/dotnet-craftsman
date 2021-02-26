using System;
using Craftsman.Domain.ValueObjects;
using Craftsman.Unit.Tests.Fixtures.ClassFixture.BirthDate;
using Xunit;

namespace Craftsman.Unit.Tests.ValueObjects
{
    public class BirthDateTest
    {
        [Theory]
        [Trait("BirthDate","Validation of role the age valid.")]
        [ClassData(typeof(AdultBirthday))]
        public void BirthDate_ValidateBirthDate_MustBeValidAndAdult(DateTime value)
        {
            BirthDate birthDate = value;
            Assert.True(birthDate.IsAdult);
        }

        [Theory]
        [Trait("BirthDate","Validation of role the age valid.")]
        [ClassData(typeof(TeenagerOrChildBirthDay))]
        public void BirthDate_ValidateBirthDate_MustBeInvalidAndNotAdult(DateTime value)
        {
            BirthDate birthDate = value;
            Assert.False(birthDate.IsAdult);
        }
    }
}