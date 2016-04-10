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
        public string MiddleNames { get; set; }
        public string Title { get; set; }
        public string PreferredName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Age { get; set; }
        public bool IsActive { get; set; }

        public int? MedicareCardNumber { get; set; }
        public DateTimeOffset? MedicareCardExpiry { get; set; }
        public int? MedicareCardPosition { get; set; }

        public PhoneNumber MobilePhoneNumber { get; set; }
        public PhoneNumber HomePhoneNumber { get; set; }
        public PhoneNumber WorkPhoneNumber { get; set; }

        public virtual EmailAddress EmailAddress { get; set; }

        public virtual Address ResidentialAddress { get; set; }

        public virtual SocialHistory SocialHistory { get; set; }
        public virtual SmokingHistory SmokingHistory { get; set; }
        public virtual AlcoholHistory AlcoholHistory { get; set; }
        public virtual DrugHistory DrugHistory { get; set; }

        public virtual ICollection<VitalSign> VitalSigns { get; set; }
    }
}
