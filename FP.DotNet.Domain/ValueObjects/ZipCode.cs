using System.Text.RegularExpressions;

namespace FP.DotNet.Domain.ValueObjects
{
    public struct ZipCode
    {
        private readonly string _value;

        private ZipCode(string value)
        => _value = value;

        public static implicit operator ZipCode(string value)
        => new(value);

        public override string ToString()
        => _value;

        public bool IsValid()
        => Regex.IsMatch(_value, "[0-9]{5}-[0-9]{3}");
    }
}