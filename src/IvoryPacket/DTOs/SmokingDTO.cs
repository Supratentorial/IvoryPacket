using System;

namespace IvoryPacket.DTOs
{
    public class SmokingDTO
    {
        public DateTime LastUpdated { get; set; }
        public string SmokingStatus { get; set; }
        public int CigarettesPerDay { get; set; }
        public int AgeStarted { get; set; }
        public int AgeCeased { get; set; }
        public string Notes { get; set; }
        public int PatientId { get; set; }
    }
}
