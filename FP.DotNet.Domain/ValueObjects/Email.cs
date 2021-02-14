using System.Text.RegularExpressions;

namespace FP.DotNet.Domain.ValueObjects
{
    public struct Email
    {
        private readonly string _value;

        public static implicit operator Email(string value)
        => new(value);

        private Email(string value)
        => _value = value;

        public override string ToString()
        => _value;

        public bool IsValid()
        => Regex
           .IsMatch(
               _value,
               @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
               RegexOptions.IgnoreCase
            );
    }
}