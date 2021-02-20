namespace Craftsman.Domain.ValueObjects
{
    public struct Cpf
    {
        public static implicit operator Cpf(string value)
        => new(value);

        private Cpf(string value)
        => _value = value;

        private readonly string _value;

        public override string ToString()
        => _value;

        public bool IsValid()
        {
            string cpf = _value
                .Trim()
                .Replace(".", string.Empty)
                .Replace("-", string.Empty);

            if (cpf.Length != 11) return false;

            string hasCpf = cpf.Substring(0, 9);
            int sum = 0;
            int[] multiplier_1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier_2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            for (int i = 0; i < 9; i++)
                sum += int.Parse(hasCpf[i].ToString()) * multiplier_1[i];

            hasCpf += HasRest(Rest(sum)).ToString();
            sum = 0;

            for (int i = 0; i < 10; i++)
                sum += int.Parse(hasCpf[i].ToString()) * multiplier_2[i];

            return VerifyingDigit(
                        cpf,
                        HasRest(Rest(sum))
                        .ToString());
        }

        private static int Rest(int sum) => sum % 11;
        private static int HasRest(int rest) => rest < 0 ? 0 : (11 - rest);
        private static bool VerifyingDigit(string cpf, string digit) => cpf.EndsWith(digit);
    }
}