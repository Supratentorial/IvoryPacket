namespace IvoryPacket.Models
{
    public class SocialHistoryObservation
    {
        public int SocialHistoryObservationId { get; set; }
        public string SmokingStatus { get; set; }
        public int CigarettesPerDay { get; set; }
        public int AgeSmokingCommenced { get; set; }
        public int AgeSmokingCeased { get; set; }
        
        //Alcohol
        public string AlcoholStatus { get; set; }
        public string DrinksPerDay { get; set; }

        //Social
        public string Ethnicity { get; set; }
        public string Occupation { get; set; }

        public virtual Patient Patient { get; set; }
        public int PatientId { get; set; }
    }
}
