using Newtonsoft.Json;

namespace IvoryPacket.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Type { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        [JsonIgnore]
        public virtual Patient Patient { get; set; }
        public int PatientId { get; set; }

    }
}
