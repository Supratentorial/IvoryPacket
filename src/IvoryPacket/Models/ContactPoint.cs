namespace IvoryPacket.Models
{
    public class ContactPoint
    {
        public int ContactPointId { get; set; }
        public int? Rank { get; set; }
        public string System { get; set; }
        public string Use { get; set; }
        public string Value { get; set; }

        public virtual Patient Patient { get; set; }
        public int PatientId { get; set; } 
    }
}
