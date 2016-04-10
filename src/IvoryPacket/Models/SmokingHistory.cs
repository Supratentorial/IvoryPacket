
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IvoryPacket.Models
{
    public class SmokingHistory
    {
        [Key]
        public int SmokingHistoryId { get; set; }
        public string SmokingStatus { get; set; }
        public int? CigarettesPerDay { get; set; }
        public int? AgeSmokingCommenced { get; set; }
        public int? AgeSmokingCeased { get; set; }
        public string Notes { get; set; }

        
        public int PatientId { get; set; }
        [JsonIgnore]
        public virtual Patient Patient { get; set; }
    }
}
