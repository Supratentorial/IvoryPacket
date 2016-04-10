using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace IvoryPacket.Models
{
    public class DrugHistory
    {
        public int DrugHistoryId { get; set; }

        
        public int PatientId { get; set; }
        [JsonIgnore]
        public virtual Patient Patient { get; set; }
    }
}
