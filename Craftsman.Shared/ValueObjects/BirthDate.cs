using System;

namespace Craftsman.Shared.ValueObjects
{
    public struct BirthDate
    {
        public int Age { get { return CalculateYear(Value.Year); } }
        public bool IsAdult { get { return CheckIfIsAdult(Value); } }
        public readonly DateTime Value {get;}

        private BirthDate(DateTime value) => Value = value;
        public static implicit operator BirthDate(DateTime value) => new(value);

        private static bool CheckIfIsAdult(DateTime value) => CalculateYear(value.Year) >= 18;
        private static int CalculateYear(int value) => DateTime.Now.Year - value;
    }
}