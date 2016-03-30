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

        public int MobilePhoneId { get; set; }
        public int MobilePhoneCountryCode { get; set; }
        public string MobilePhoneNumber { get; set; }
        public int HomePhoneId { get; set; }
        public int HomePhoneCountryCode { get; set; }
        public string HomePhoneAreaCode { get; set; }
        public string HomePhoneNumber { get; set; }
        public int WorkPhoneId { get; set; }
        public int WorkPhoneCountryCode { get; set; }
        public string WorkPhoneAreaCode { get; set; }
        public string WorkPhoneNumber { get; set; }
        public string PreferredContact { get; set; }

        public virtual EmailAddress EmailAddress { get; set; }

        public int ResidentialAddressId { get; set; }
        public string ResidentialAddressNumber { get; set; }
        public string ResidentialAddressStreet { get; set; }
        public string ResidentialAddressState { get; set; }
        public string ResidentialAddressSuburb { get; set; }
        public string ResidentialAddressPostalCode { get; set; }
    }
}
