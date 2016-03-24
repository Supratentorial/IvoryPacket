namespace IvoryPacket.Models
{
    public class Observation
    {
        public int ObservationId { get; set; }
        public string Status { get; set; } //registered | preliminary | final | amended
        public string Category { get; set; } //social history | vital signs | imaging | laboratory | procedure | survey | exam | therapy
        public string Type { get; set; }
        public int? Code { get; set; } //Type of observation LOINC/Snomed code
        public string Method { get; set; } //How it was done
        public int SubjectId { get; set; }

        public virtual StaffMember Performer { get; set; }
        public virtual Patient Subject { get; set; }
        public virtual Encounter Encounter { get; set; }
    }
}
