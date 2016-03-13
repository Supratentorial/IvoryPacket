using System;

namespace IvoryPacket.DTOs
{
    public class PatientSimpleDTO
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
    }
}
