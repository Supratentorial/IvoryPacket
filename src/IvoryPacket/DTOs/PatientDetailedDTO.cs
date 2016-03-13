using IvoryPacket.Models;
using System;
using System.Collections.Generic;

namespace IvoryPacket.DTOs
{
    public class PatientDetailedDTO
    {
        public int PatientId { get; set; }
        public string FullName { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Title { get; set; }
        public string PreferredName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Age { get; set; }
        public bool IsActive { get; set; }

        public string Ethnicity { get; set; }

        public int? MedicareCardNumber { get; set; }
        public DateTimeOffset? MedicareCardExpiry { get; set; }
        public int? MedicareCardPosition { get; set; }

        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public virtual EmailAddress EmailAddress { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Allergy> Allergies { get; set; }

    }
}
