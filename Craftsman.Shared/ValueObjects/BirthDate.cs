using System;

namespace Craftsman.Shared.ValueObjects
{
    public struct BirthDate
    {
        private readonly DateTime _value;

        public int Age { get { return CalculateYear(_value.Year); } }
        public bool IsAdult { get { return CheckIfIsAdult(_value); } }

        private BirthDate(DateTime value)
        => _value = value;

        public static implicit operator BirthDate(DateTime value)
        => new(value);

        private static bool CheckIfIsAdult(DateTime value)
        => CalculateYear(value.Year) >= 18;

        private static int CalculateYear(int value)
        => DateTime.Now.Year - value;
    }
}