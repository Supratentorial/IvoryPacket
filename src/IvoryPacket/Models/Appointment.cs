using System;

namespace IvoryPacket.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public string AppointmentType { get; set; }
        public DateTime? AppointmentTime { get; set; }

        public virtual Patient Patient { get; set; }
        public int PatientId { get; set; }
        
    }
}
