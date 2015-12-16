using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IvoryPacket.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<HumanName> HumanNames { get; set; }
        public virtual ICollection<ContactPoint> Telecom { get; set; }
        public virtual ICollection<Allergy> Allergies { get; set; }
    }
}
