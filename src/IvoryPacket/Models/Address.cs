namespace IvoryPacket.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        //public Period Period { get; set; }
    }
}
