namespace IvoryPacket.Models
{
    public class ContactPoint
    {
        public Period Period { get; set; }
        public int? Rank { get; set; }
        public string System { get; set; }
        public string TypeName { get; }
        public string Use { get; set; }
        public string Value { get; set; }
    }
}
