using System;

namespace IvoryPacket.DTOs
{
    public class VitalsDTO
    {
        public int VitalsId { get; set; }
        public DateTime DateRecorded { get; set; }
        public float Temperature { get; set; }
        public int HeartRate { get; set; }
        public int RespiratoryRate { get; set; }
        public int OxygenSaturation { get; set; }
        public int SystolicBloodPressure { get; set; }
        public int DiastolicBloodPressure { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public int PerformerId { get; set; }
        public string PerformerName { get; set; }
    }
}
