namespace FP.DotNet.Domain.ValueObjects
{
    public struct Address
    {
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}