using System.ComponentModel.DataAnnotations.Schema;

namespace IvoryPacket.Models
{
    public class EmailAddress
    {
        public int EmailAddressId { get; set; }
        public string EmailValue { get; set; }
        public bool IsPreferred { get; set; }
        public virtual Patient Patient { get; set; }
        [ForeignKey("PatientId")]
        public int PatientId { get; set; }
    }
}
