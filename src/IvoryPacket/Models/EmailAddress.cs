using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IvoryPacket.Models
{
    public class EmailAddress
    {
        public int EmailAddressId { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string EmailValue { get; set; }
        public bool IsPreferred { get; set; } = true;
        [JsonIgnore]
        public virtual Patient Patient { get; set; }
        [ForeignKey("PatientId")]
        public int PatientId { get; set; }
    }
}
