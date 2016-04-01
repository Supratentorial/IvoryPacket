using IvoryPacket.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Column(TypeName = "Date")]
        public DateTime DateOfBirth { get; set; }

        public int? MedicareCardNumber { get; set; }
        public DateTimeOffset? MedicareCardExpiry { get; set; }
        public int? MedicareCardPosition { get; set; }

        public bool IsActive { get; set; }
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public virtual EmailAddress EmailAddress { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Allergy> Allergies { get; set; }
        public virtual ICollection<VitalSign> VitalSigns { get; set; }
        public virtual SocialHistoryObservation SocialHistoryObservation { get; set; }

        public string GetFullName()
        {
            return GivenName + " " + FamilyName;
        }

        public string GetFullNameWithTitle()
        {
            return FamilyName.ToUpper() + ", " + GivenName + "(" + Title + ")";
        }  

        public string GetAgeString()
        {
            return DateTimeExtensions.ToAgeString(DateOfBirth);
        }

    }
}
