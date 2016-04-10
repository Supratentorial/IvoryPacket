using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace IvoryPacket.Models
{
    public class PhoneNumber
    {
        public int PhoneNumberId { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string CountryCode { get; set; }
        public string AreaCode { get; set; }
        [Required(AllowEmptyStrings =false)]
        public string Value { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Type { get; set; }
        public bool? IsPreferred { get; set; }
        [JsonIgnore]
        public virtual Patient Patient { get; set; }
        public int PatientId { get; set; }
    }
}
