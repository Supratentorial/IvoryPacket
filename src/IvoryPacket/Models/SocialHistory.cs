using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace IvoryPacket.Models
{
    public class SocialHistory
    {
        public int SocialHistoryId { get; set; }

        //Social
        public string Ethnicity { get; set; }
        public string Occupation { get; set; }
        public string MaritalStatus { get; set; }
        public string Religion { get; set; }
        [JsonIgnore]
        public virtual Patient Patient { get; set; }
        public int PatientId { get; set; }
    }
}
