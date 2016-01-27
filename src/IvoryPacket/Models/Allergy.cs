using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IvoryPacket.Models
{
    public class Allergy
    {
        public int AllergyId { get; set; }
        public DateTimeOffset? RecordedDate { get; set; }
        public string Substance { get; set; }
        public string Type { get; set; } //Allergy vs medication side effect 
        public string Severity { get; set; }
        public string ClinicalManifestation { get; set; }
        public string Note { get; set; }

        [ForeignKey("PatientId")]
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; } 
    }
}
