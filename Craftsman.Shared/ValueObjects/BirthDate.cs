using System;

namespace Craftsman.Shared.ValueObjects
{
    public struct BirthDate
    {
        public DateTime Date { get; }
        public int Age { get { return CalculateYear(Date.Year); } }
        public bool IsAdult { get { return CheckIfIsAdult(Date); } }

        private BirthDate(DateTime value)
        => Date = value;

        public static implicit operator BirthDate(DateTime value)
        => new(value);

        private static bool CheckIfIsAdult(DateTime value)
        => CalculateYear(value.Year) >= 18;

        private static int CalculateYear(int value)
        => DateTime.Now.Year - value;
    }
}