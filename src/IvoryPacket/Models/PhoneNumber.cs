namespace IvoryPacket.Models
{
    public class PhoneNumber
    {
        public int PhoneNumberId { get; set; }
        public string CountryCode { get; set; }
        public string AreaCode { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public bool IsPreferred { get; set; }
    }
}
