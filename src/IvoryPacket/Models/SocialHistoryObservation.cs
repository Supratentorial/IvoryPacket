namespace IvoryPacket.Models
{
    public class SocialHistoryObservation
    {
        public int SocialHistoryObservationId { get; set; }
        public string SmokingStatus { get; set; }
        public int CigarettesPerDay { get; set; }
        public int AgeCommenced { get; set; }
        public int AgeCeased { get; set; }
        public virtual Patient Patient { get; set; }
        public int PatientId { get; set; }
    }
}
