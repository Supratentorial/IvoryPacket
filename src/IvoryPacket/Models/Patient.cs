using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IvoryPacket.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string Title { get; set; }
        public string GivenName { get; set; }
        public string MiddleNames { get; set; }
        public string FamilyName { get; set; }
        public string PreferredName { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public string Ethnicity { get; set; }
        
        public int? MedicareCardNumber { get; set; }
        public DateTime? MedicareCardExpiry { get; set; }
        public int? MedicareCardPosition { get; set; }

        public bool IsActive { get; set; }
        public virtual ICollection<ContactPoint> ContactPoints { get; set; }
        public virtual ICollection<Allergy> Allergies { get; set; }
    }
}
