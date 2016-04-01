using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IvoryPacket.Models
{
    public class VitalSign
    {
        public int VitalSignId { get; set; }
        public string Status { get; set; } //registered | preliminary | final | amended
        public DateTime DateRecorded { get; set; }
        public float Temperature { get; set; }
        public int HeartRate { get; set; }
        public int RespiratoryRate { get; set; }
        public int OxygenSaturation { get; set; }
        public int SystolicBloodPressure { get; set; }
        public int DiastolicBloodPressure { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }

        public virtual Patient Subject { get; set; }
        public int SubjectId { get; set; }

        //public virtual Encounter Encounter { get; set; }
        //public int EncounterId { get; set; }
    }
}
