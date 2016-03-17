namespace IvoryPacket.Models
{
    public class VitalObservation
    {
        public int VitalObservationId { get; set; }
        public int? SystolicBloodPressure { get; set; }
        public int? DiastolicBloodPressure { get; set; }
        public int? HeartRate { get; set; }
        public string HeartRhythm { get; set; }
        public int? RespiratoryRate { get; set; }
        public int? OxygenSaturation { get; set; }
        public float? Temperature { get; set; }
        public float? Weight { get; set; }
        public float? Height { get; set; }
    }
}
