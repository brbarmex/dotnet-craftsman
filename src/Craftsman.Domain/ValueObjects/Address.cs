namespace Craftsman.Domain.ValueObjects
{
    public struct Address
    {
        public string Street { get; set; }
        public ZipCode ZipCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}