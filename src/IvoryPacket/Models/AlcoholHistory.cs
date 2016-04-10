using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IvoryPacket.Models
{
    public class AlcoholHistory
    {
        [Key]
        public int AlcoholHistoryId { get; set; }
        public string AlcoholStatus { get; set; }
        public string DrinksPerDay { get; set; }

        
        public int PatientId { get; set; }
        [JsonIgnore]
        public virtual Patient Patient { get; set; }
    }
}
